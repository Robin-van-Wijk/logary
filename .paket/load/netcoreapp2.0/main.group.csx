namespace PaketLoadScripts

#r "../../../packages/Expecto.BenchmarkDotNet/lib/netcoreapp2.0/Expecto.BenchmarkDotNet.dll" 
#r "../../../packages/Microsoft.TestPlatform.ObjectModel/lib/netstandard1.5/Microsoft.TestPlatform.PlatformAbstractions.dll" 
#r "../../../packages/RabbitMQ.Client/lib/netstandard1.5/RabbitMQ.Client.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.Security.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.Core.dll" 
#r "../../../packages/EventStore.ClientAPI.NetCore/lib/netstandard2.0/EventStore.ClientAPI.NetCore.dll" 
#r "../../../packages/Machine.Specifications.Should/lib/netstandard1.3/Machine.Specifications.Should.dll" 
#r "../../../packages/BenchmarkDotNet.Core/lib/netcoreapp2.0/BenchmarkDotNet.Core.dll" 
#r "../../../packages/Machine.Specifications/lib/netstandard1.3/Machine.Specifications.dll" 
#r "../../../packages/Mono.Cecil/lib/netstandard1.3/Mono.Cecil.dll" 
#r "../../../packages/protobuf-net/lib/netstandard2.0/protobuf-net.dll" 
#r "../../../packages/System.Private.DataContractSerialization/lib/netstandard1.3/System.Private.DataContractSerialization.dll" 
#r "../../../packages/System.Xml.XmlSerializer/lib/netstandard1.3/System.Xml.XmlSerializer.dll" 
#r "../../../packages/System.Xml.XPath.XmlDocument/lib/netstandard1.3/System.Xml.XPath.XmlDocument.dll" 
#r "../../../packages/System.ComponentModel.TypeConverter/lib/netstandard1.5/System.ComponentModel.TypeConverter.dll" 
#r "../../../packages/System.Dynamic.Runtime/lib/netstandard1.3/System.Dynamic.Runtime.dll" 
#r "../../../packages/System.Xml.XDocument/lib/netstandard1.3/System.Xml.XDocument.dll" 
#r "../../../packages/System.Xml.XmlDocument/lib/netstandard1.3/System.Xml.XmlDocument.dll" 
#r "../../../packages/System.Xml.XPath/lib/netstandard1.3/System.Xml.XPath.dll" 
#r "../../../packages/FsPickler/lib/netstandard2.0/FsPickler.dll" 
#r "../../../packages/Http.fs/lib/netstandard2.0/HttpFs.dll" 
#r "../../../packages/Microsoft.DotNet.InternalAbstractions/lib/netstandard1.3/Microsoft.DotNet.InternalAbstractions.dll" 
#r "../../../packages/Microsoft.DotNet.PlatformAbstractions/lib/netstandard1.3/Microsoft.DotNet.PlatformAbstractions.dll" 
#r "../../../packages/System.Collections.Specialized/lib/netstandard1.3/System.Collections.Specialized.dll" 
#r "../../../packages/System.Diagnostics.TextWriterTraceListener/lib/netstandard1.3/System.Diagnostics.TextWriterTraceListener.dll" 
#r "../../../packages/System.Linq.Expressions/lib/netstandard1.6/System.Linq.Expressions.dll" 
#r "../../../packages/System.Xml.ReaderWriter/lib/netstandard1.3/System.Xml.ReaderWriter.dll" 
#r "../../../packages/System.Collections.Concurrent/lib/netstandard1.3/System.Collections.Concurrent.dll" 
#r "../../../packages/System.Collections.NonGeneric/lib/netstandard1.3/System.Collections.NonGeneric.dll" 
#r "../../../packages/System.ComponentModel.EventBasedAsync/lib/netstandard1.3/System.ComponentModel.EventBasedAsync.dll" 
#r "../../../packages/System.ComponentModel.Primitives/lib/netstandard1.0/System.ComponentModel.Primitives.dll" 
#r "../../../packages/System.Linq/lib/netstandard1.6/System.Linq.dll" 
#r "../../../packages/System.Net.WebHeaderCollection/lib/netstandard1.3/System.Net.WebHeaderCollection.dll" 
#r "../../../packages/System.ObjectModel/lib/netstandard1.3/System.ObjectModel.dll" 
#r "../../../packages/System.Reflection.Emit/lib/netstandard1.3/System.Reflection.Emit.dll" 
#r "../../../packages/System.Reflection.Emit.Lightweight/lib/netstandard1.3/System.Reflection.Emit.Lightweight.dll" 
#r "../../../packages/System.Runtime.InteropServices.RuntimeInformation/lib/netstandard1.1/System.Runtime.InteropServices.RuntimeInformation.dll" 
#r "../../../packages/System.Runtime.Numerics/lib/netstandard1.3/System.Runtime.Numerics.dll" 
#r "../../../packages/System.Runtime.Serialization.Primitives/lib/netstandard1.3/System.Runtime.Serialization.Primitives.dll" 
#r "../../../packages/System.Security.Claims/lib/netstandard1.3/System.Security.Claims.dll" 
#r "../../../packages/System.Security.Cryptography.Primitives/lib/netstandard1.3/System.Security.Cryptography.Primitives.dll" 
#r "../../../packages/System.Text.RegularExpressions/lib/netstandard1.6/System.Text.RegularExpressions.dll" 
#r "../../../packages/Argu/lib/netstandard2.0/Argu.dll" 
#r "../../../packages/System.Diagnostics.StackTrace/lib/netstandard1.3/System.Diagnostics.StackTrace.dll" 
#r "../../../packages/System.Reflection.Emit.ILGeneration/lib/netstandard1.3/System.Reflection.Emit.ILGeneration.dll" 
#r "../../../packages/System.Runtime.Loader/lib/netstandard1.5/System.Runtime.Loader.dll" 
#r "../../../packages/Google.Cloud.Logging.Type/lib/netstandard1.5/Google.Cloud.Logging.Type.dll" 
#r "../../../packages/System.Data.SqlClient/lib/netstandard2.0/System.Data.SqlClient.dll" 
#r "../../../packages/Autofac/lib/netstandard1.1/Autofac.dll" 
#r "../../../packages/System.Threading/lib/netstandard1.3/System.Threading.dll" 
#r "../../../packages/System.Threading.ThreadPool/lib/netstandard1.3/System.Threading.ThreadPool.dll" 
#r "../../../packages/FParsec/lib/netstandard1.6/FParsecCS.dll" 
#r "../../../packages/FsCheck/lib/netstandard1.6/FsCheck.dll" 
#r "../../../packages/Google.Protobuf/lib/netstandard1.0/Google.Protobuf.dll" 
#r "../../../packages/lz4net.unsafe.netcore/lib/netstandard1.0/LZ4pn.dll" 
#r "../../../packages/Microsoft.Extensions.PlatformAbstractions/lib/netstandard1.3/Microsoft.Extensions.PlatformAbstractions.dll" 
#r "../../../packages/System.AppContext/lib/netstandard1.6/System.AppContext.dll" 
#r "../../../packages/System.ComponentModel/lib/netstandard1.3/System.ComponentModel.dll" 
#r "../../../packages/System.Interactive.Async/lib/netstandard1.3/System.Interactive.Async.dll" 
#r "../../../packages/System.IO.FileSystem.Primitives/lib/netstandard1.3/System.IO.FileSystem.Primitives.dll" 
#r "../../../packages/System.Security.Cryptography.ProtectedData/lib/netstandard2.0/System.Security.Cryptography.ProtectedData.dll" 
#r "../../../packages/System.Security.Principal/lib/netstandard1.0/System.Security.Principal.dll" 
#r "../../../packages/System.Threading.Thread/lib/netstandard1.3/System.Threading.Thread.dll" 
#r "../../../packages/fszmq/lib/netstandard2.0/fszmq.dll" 
#r "../../../packages/Google.Apis.Core/lib/netstandard2.0/Google.Apis.Core.dll" 
#r "../../../packages/Suave/lib/netstandard2.0/Suave.dll" 
#r "../../../packages/System.Security.Cryptography.Cng/lib/netstandard2.0/System.Security.Cryptography.Cng.dll" 
#r "../../../packages/System.Security.Cryptography.OpenSsl/lib/netstandard2.0/System.Security.Cryptography.OpenSsl.dll" 
#r "../../../packages/System.Security.Principal.Windows/lib/netstandard2.0/System.Security.Principal.Windows.dll" 
#r "../../../packages/Unquote/lib/netstandard2.0/Unquote.dll" 
#r "../../../packages/elmah.corelibrary/lib/Elmah.dll" 
#r "../../../packages/FSharp.Core/lib/netstandard1.6/FSharp.Core.dll" 
#r "../../../packages/Microsoft.CodeCoverage/lib/netstandard1.0/Microsoft.VisualStudio.CodeCoverage.Shim.dll" 
#r "../../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll" 
#r "../../../packages/NitoAsyncEx.Context.StrongName/lib/netstandard1.4/Nito.Disposables.dll" 
#r "../../../packages/NLog/lib/netstandard2.0/NLog.dll" 
#r "../../../packages/System.Diagnostics.DiagnosticSource/lib/netstandard1.3/System.Diagnostics.DiagnosticSource.dll" 
#r "../../../packages/System.Runtime.CompilerServices.Unsafe/lib/netcoreapp2.0/System.Runtime.CompilerServices.Unsafe.dll" 
#r "../../../packages/System.Threading.Tasks.Parallel/lib/netstandard1.3/System.Threading.Tasks.Parallel.dll" 
#r "../../../packages/Topshelf/lib/netstandard2.0/Topshelf.dll" 
#r "../../../packages/BenchmarkDotNet/lib/netcoreapp2.0/BenchmarkDotNet.dll" 
#r "../../../packages/Microsoft.ApplicationInsights/lib/netstandard1.3/Microsoft.ApplicationInsights.dll" 
#r "../../../packages/Google.Api.Gax/lib/netstandard1.3/Google.Api.Gax.dll" 
#r "../../../packages/Microsoft.TestPlatform.ObjectModel/lib/netstandard1.5/Microsoft.TestPlatform.CoreUtilities.dll" 
#r "../../../packages/NodaTime/lib/netstandard1.3/NodaTime.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.WebLogic.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.Streams.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.Logic.dll" 
#r "../../../packages/Expecto/lib/netstandard2.0/Expecto.dll" 
#r "../../../packages/Microsoft.CodeAnalysis.Common/lib/netstandard1.3/Microsoft.CodeAnalysis.dll" 
#r "../../../packages/System.Runtime.Serialization.Json/lib/netstandard1.3/System.Runtime.Serialization.Json.dll" 
#r "../../../packages/System.Runtime.Serialization.Xml/lib/netstandard1.3/System.Runtime.Serialization.Xml.dll" 
#r "../../../packages/Mono.Cecil/lib/netstandard1.3/Mono.Cecil.Rocks.dll" 
#r "../../../packages/Mono.Cecil/lib/netstandard1.3/Mono.Cecil.Pdb.dll" 
#r "../../../packages/Mono.Cecil/lib/netstandard1.3/Mono.Cecil.Mdb.dll" 
#r "../../../packages/Castle.Core/lib/netstandard1.3/Castle.Core.dll" 
#r "../../../packages/Microsoft.Extensions.DependencyModel/lib/netstandard1.6/Microsoft.Extensions.DependencyModel.dll" 
#r "../../../packages/System.Xml.XPath.XDocument/lib/netstandard1.3/System.Xml.XPath.XDocument.dll" 
#r "../../../packages/Grpc.Core/lib/netstandard1.5/Grpc.Core.dll" 
#r "../../../packages/Google.Api.CommonProtos/lib/netstandard1.3/Google.Api.CommonProtos.dll" 
#r "../../../packages/lz4net/lib/netstandard1.0/LZ4.dll" 
#r "../../../packages/FParsec/lib/netstandard1.6/FParsec.dll" 
#r "../../../packages/Google.Apis/lib/netstandard2.0/Google.Apis.dll" 
#r "../../../packages/Microsoft.Rest.ClientRuntime/lib/netstandard1.4/Microsoft.Rest.ClientRuntime.dll" 
#r "../../../packages/System.Security.AccessControl/lib/netstandard2.0/System.Security.AccessControl.dll" 
#r "../../../packages/FsPickler.Json/lib/netstandard2.0/FsPickler.Json.dll" 
#r "../../../packages/Hopac/lib/netstandard2.0/Hopac.Core.dll" 
#r "../../../packages/System.Memory/lib/netstandard2.0/System.Memory.dll" 
#r "../../../packages/System.Text.Encoding.CodePages/lib/netstandard2.0/System.Text.Encoding.CodePages.dll" 
#r "../../../packages/NitoAsyncEx.Context.StrongName/lib/netstandard1.4/Nito.AsyncEx.Tasks.dll" 
#r "../../../packages/Google.Cloud.Logging.V2/lib/netstandard1.5/Google.Cloud.Logging.V2.dll" 
#r "../../../packages/Microsoft.ApplicationInsights.DependencyCollector/lib/netstandard1.6/Microsoft.AI.DependencyCollector.dll" 
#r "../../../packages/Google.Api.Gax.Rest/lib/netstandard1.3/Google.Api.Gax.Rest.dll" 
#r "../../../packages/Expecto.FsCheck/lib/netstandard2.0/Expecto.FsCheck.dll" 
#r "../../../packages/Expecto.Hopac/lib/netstandard2.0/Expecto.Hopac.dll" 
#r "../../../packages/Microsoft.CodeAnalysis.CSharp/lib/netstandard1.3/Microsoft.CodeAnalysis.CSharp.dll" 
#r "../../../packages/Microsoft.TestPlatform.ObjectModel/lib/netstandard1.5/Microsoft.VisualStudio.TestPlatform.ObjectModel.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.Factories.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.Credentials.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.Controllers.dll" 
#r "../../../packages/Grpc.Auth/lib/netstandard1.5/Grpc.Auth.dll" 
#r "../../../packages/aliyun-log-csharp-sdk/lib/netstandard2.0/Aliyun.Api.Log.dll" 
#r "../../../packages/elmah.io.client/lib/netstandard1.4/Elmah.Io.Client.dll" 
#r "../../../packages/Google.Apis.Auth/lib/netstandard2.0/Google.Apis.Auth.dll" 
#r "../../../packages/Microsoft.Win32.Registry/lib/netstandard2.0/Microsoft.Win32.Registry.dll" 
#r "../../../packages/System.Security.Permissions/lib/netstandard2.0/System.Security.Permissions.dll" 
#r "../../../packages/Hopac/lib/netstandard2.0/Hopac.Platform.dll" 
#r "../../../packages/Hopac/lib/netstandard2.0/Hopac.dll" 
#r "../../../packages/NitoAsyncEx.Context.StrongName/lib/netstandard1.4/Nito.AsyncEx.Context.dll" 
#r "../../../packages/Google.Api.Gax.Grpc/lib/netstandard1.5/Google.Api.Gax.Grpc.dll" 
#r "../../../packages/Microsoft.TestPlatform.TestHost/lib/netstandard1.5/Microsoft.VisualStudio.TestPlatform.Common.dll" 
#r "../../../packages/TweetinviAPI/lib/netstandard1.4/Tweetinvi.dll" 
#r "../../../packages/System.Configuration.ConfigurationManager/lib/netstandard2.0/System.Configuration.ConfigurationManager.dll" 
#r "../../../packages/Google.Apis.Auth/lib/netstandard2.0/Google.Apis.Auth.PlatformServices.dll" 
#r "../../../packages/Microsoft.TestPlatform.TestHost/lib/netstandard1.5/Microsoft.TestPlatform.CommunicationUtilities.dll" 
#r "../../../packages/Microsoft.TestPlatform.TestHost/lib/netstandard1.5/Microsoft.TestPlatform.CrossPlatEngine.dll" 
#r "../../../packages/Microsoft.TestPlatform.TestHost/lib/netstandard1.5/testhost.dll" 
#r "System" 
#r "System.Configuration.Install" 
#r "System.Core" 
#r "System.ServiceProcess" 
#r "mscorlib" 
#r "System.Numerics" 
#r "System.IO.Compression" 
#r "Java.Interop" 
#r "Mono.Android" 
#r "System.Runtime" 
#r "System.Xml" 
#r "System.Xml.Linq" 
#r "System.Configuration" 
#r "System.Data" 
#r "System.Runtime.Serialization" 
#r "System.ServiceModel" 
#r "System.Transactions" 
#r "Microsoft.CSharp" 
#r "System.Net" 
#r "System.Windows" 
#r "System.Windows.Browser" 
#r "Xamarin.iOS" 
#r "System.ComponentModel.Composition" 
#r "System.Net.Http" 
#r "System.Security" 
#r "System.Data.OracleClient" 
#r "System.Drawing" 
#r "System.Runtime.Remoting" 
#r "System.Xml.Serialization" 
#r "System.Management" 