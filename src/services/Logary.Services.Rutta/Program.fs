module Logary.Services.Rutta.Program

open Argu
open System
open System.Configuration
open System.Threading
open System.Runtime.InteropServices
open Topshelf
open Logary
open Logary.Services.Rutta

let versionAndName = sprintf "Logary Rutta v%s" AssemblyVersionInformation.AssemblyVersion

let maybeSubcommand (argv: string[]): string[] =
  let found = ConfigurationManager.AppSettings.["subcommand"]
  if isNull found then argv else
  let subArgv = ConfigurationManager.AppSettings.[found]
  if isNull subArgv then [| yield found; yield! argv |] else
  let subCmdArgv = subArgv.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries)
  [| yield found; yield! subCmdArgv; yield! argv |]

let executeProxy (args: ParseResults<ProxyArgs>) =
  Proxy.proxy (args.GetResult Xsub_Connect_To) (args.GetResult Xpub_Bind)

let executeRouter (ilevel: LogLevel) (args: ParseResults<RouterArgs>) =
  let listeners = args.GetResults RouterArgs.Listener
  let targets = args.PostProcessResults(RouterArgs.Target, Parsers.targetConfig)
  if List.isEmpty listeners || List.isEmpty targets then
    failwith "Router `--listener` arguments empty, or `--target` arguments empty"
  Router.start ilevel targets listeners

let executeShipper (args: ParseResults<ShipperArgs>) =
  match args.GetAllResults() |> List.head with
  | Pub_To binding ->
    Shipper.pubTo binding
  | Push_To connect ->
    Shipper.pushTo connect

let executeSubCommand (ilevel: LogLevel) =
  function
  | Proxy args ->
    executeProxy args
  | Router args ->
    executeRouter ilevel args
  | Shipper args ->
    executeShipper args
  | other ->
    failwith "Sub-command %A not handled in `executeSubCommand`. Send a PR?"

let execute argv (exiting: ManualResetEventSlim): int =
  let argv = maybeSubcommand argv
  let parser = ArgumentParser.Create<Args>(programName = "rutta.exe", helpTextMessage = versionAndName)
  let parsed = parser.Parse(argv, ignoreUnrecognized=true, raiseOnUsage=false)

  if parsed.Contains Version || parsed.IsUsageRequested then
    printfn "%s" (parser.PrintUsage())
    0
  else
    let ilevel = if parsed.Contains Args.Verbose then LogLevel.Verbose else LogLevel.Info
    use health = parsed.TryGetResult Args.Health |> Option.map Parsers.binding |> Health.startServer
    match parsed.TryGetSubCommand() with
    | Some cmd ->
      use running = executeSubCommand ilevel cmd
      exiting.Wait()
      0

    | None ->
      eprintfn "%s" (parser.PrintUsage())
      10

let startWindows argv: int =
  let exiting = new ManualResetEventSlim(false)

  let enqueue f =
    ThreadPool.QueueUserWorkItem(fun _ -> f ()) |> ignore

  let start hc =
    enqueue (fun _ -> execute argv exiting |> ignore)
    true

  let stop hc =
    exiting.Dispose()
    true

  defaultService
  |> withRecovery (
      defaultServiceRecovery
      |> restart (Time.s 5)
      |> restart (Time.s 5)
      |> restart (Time.s 5))
  |> withStart start
  |> withStop (fun hc -> exiting.Set() ; stop hc)
  |> run

let startUnix argv: int =
  let exiting = new ManualResetEventSlim(false)
  use sub = Console.CancelKeyPress.Subscribe(fun _ -> exiting.Set())
  execute argv exiting

[<EntryPoint>]
let main argv =
  let osDesc = RuntimeInformation.OSDescription
  eprintfn "Rutta running on '%s'" osDesc
  let isDashed = argv.Length >= 1 && argv.[0] = "--"
  if osDesc.Contains "Linux" || osDesc.Contains "Unix" || osDesc.Contains "Darwin" || isDashed then
    startUnix (if isDashed then argv.[1..] else argv)
  else
    startWindows argv