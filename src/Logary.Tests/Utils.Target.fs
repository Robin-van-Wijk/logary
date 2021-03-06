[<AutoOpen>]
module Logary.Tests.TargetUtils

open System
open System.IO
open Hopac
open NodaTime
open Expecto
open Expecto.Logging

let internal logger = Log.create "Logary.Tests.Utils"

let env defaultValue k =
  match Environment.GetEnvironmentVariable k with
  | null when isNull defaultValue ->
    failwithf "Couldn't load key %s" k
  | null ->
    defaultValue
  | v ->
    v

open Logary
open Logary.Internals
open Logary.Targets
open Logary.Configuration

let clearStream (s: System.IO.StringWriter) =
  let sb = s.GetStringBuilder ()
  let str = string sb
  sb.Clear () |> ignore
  str

let buildTextWriterTarget name =
  let (out, error) = (new StringWriter (), new StringWriter ())
  let twconf = TextWriter.TextWriterConf.create (out, error, MessageWriter.multiLineWithContext)
  let twTargetConf = TextWriter.create twconf name
  (out, error, twTargetConf)

let buildLogManagerWith configFac = job {
  let svc = "svc"
  let host = "localhost"
  let tname = "4test"
  let out, error, twTargetConf = buildTextWriterTarget tname
  // let iloggerConf = ILogger.Targets [ twTargetConf ]

  let! logm =
    Config.create svc host
    |> Config.target twTargetConf
    |> Config.processing (Events.events |> Events.sink [tname])
    |> Config.disableGlobals
    |> configFac
    |> Config.build
  return logm, out, error
}

let buildLogManager () = buildLogManagerWith id


let emptyRuntime =
  memo (
    Config.createInternalTargets (ILogger.LiterateConsole Verbose)
    |> Config.createInternalLogger (RuntimeInfo.create "logary-tests" "dev-machine")
    |> Job.map (fun (ri, _) -> ri)
  )

let nanos xs =
  Duration.FromTicks (xs / Constants.NanosPerTick)

module Internals =
  type TimeoutResult<'T> =
    | Success of 'T
    | TimedOut

let finaliseJob target =
  Alt.choose [
    Target.shutdown target
    |> Alt.afterJob id
    |> Alt.afterFun Internals.Success

    timeOutMillis 8000
      |> Alt.afterFun (fun _ -> Internals.TimedOut)
  ]

/// Finalise the target and assert it was finalised within 1000 milliseconds
let finalise target =
  finaliseJob target |> Alt.afterFun (function
    | Internals.TimedOut ->
      failtestf "Finalising target timed out: %A" target
    | Internals.Success _ ->
      ())

let logMsgWaitAndShutdown (targetApi: Target.T) (logCallBack: (Message -> Job<unit>) -> #Job<unit>) =
  let logAndWait (message: Message) =
    job {
      do! logger.infoWithBP (Logging.Message.eventX (sprintf "Sending message to Target(%s)" targetApi.name))
      let! res = Target.log Duration.Zero targetApi message
      match res with
      | Ok ack ->
        do! logger.infoWithBP (Logging.Message.eventX (sprintf "Waiting for Target(%s) to ACK message" targetApi.name))
        do! ack
        do! logger.infoWithBP (Logging.Message.eventX (sprintf "Target(%s) ACKed message" targetApi.name))
      | Result.Error e ->
        failtestf "%A" e
    }
  let finaliseJob =
    job {
      do! logger.infoWithBP (Logging.Message.eventX "Finalising target")
      do! finalise targetApi
      do! logger.infoWithBP (Logging.Message.eventX "Target finalised!")
    }

  Job.tryFinallyJob (logCallBack logAndWait) finaliseJob

let testLabel label test =
  TestLabel (label, test, FocusState.Normal)

