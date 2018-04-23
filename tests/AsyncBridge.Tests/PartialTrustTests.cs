using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if NET45
using TaskEx = System.Threading.Tasks.Task;
#endif

#if NET45
namespace ReferenceAsync.Tests
#elif NET35
namespace AsyncBridge.Net35.Tests
#elif ATP
namespace AsyncTargetingPack.Tests
#else
namespace AsyncBridge.Tests
#endif
{
#if !ATP
    public sealed class Sandbox : IDisposable
    {
        private readonly AppDomain _Sandbox;

        public Sandbox()
        {
            var CurrentSetup = AppDomain.CurrentDomain.SetupInformation;
            var MySetup = new AppDomainSetup()
            {
                ApplicationBase = CurrentSetup.ApplicationBase
            };

            var MyPermissions = new PermissionSet(PermissionState.None);
            MyPermissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            // Ensure we can read our own assemblies and files
            MyPermissions.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, CurrentSetup.ApplicationBase));

            _Sandbox = AppDomain.CreateDomain(
                "Partial Trust Tests",
                AppDomain.CurrentDomain.Evidence,
                MySetup,
                MyPermissions,
#if NET45
                new StrongName[0]
#else
                // AsyncBridge and AsyncTargetingPack need full trust to work. The test classes remain untrusted
                new StrongName[] { CreateStrongName(typeof(TaskEx).Assembly.GetName()) }
#endif
                );

            _Sandbox.UnhandledException += OnUnhandledException;
        }

        public TRemote Create<TRemote>() where TRemote : MarshalByRefObject
        {
            // This does not demand ReflectionPermission, so we don't need to give the test assembly full trust
            return (TRemote)Activator.CreateInstanceFrom(_Sandbox, typeof(TRemote).Assembly.ManifestModule.FullyQualifiedName, typeof(TRemote).FullName).Unwrap();
        }

        public void Dispose()
        {
            AppDomain.Unload(_Sandbox);
        }

        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Write.Line(string.Format("Unhandled Remote Exception {0}", e.ExceptionObject.ToString()));
            throw new ApplicationException("Unhandled Remote Exception", (Exception)e.ExceptionObject);
        }

        private static StrongName CreateStrongName(AssemblyName assemblyName)
        { //****************************************
            var MyPublicKey = assemblyName.GetPublicKey();
            //****************************************

            if (MyPublicKey == null || MyPublicKey.Length == 0)
                throw new InvalidOperationException(string.Format("Assembly Name for {0} must specify the full Public Key", assemblyName.Name));

            return new StrongName(new StrongNamePublicKeyBlob(MyPublicKey), assemblyName.Name, assemblyName.Version);
        }
    }

    [TestClass]
    public class PartialTrustTests
    {
        public PartialTrustTests()
        {
            // Forces .Net to load the culture-specific assembly for exception messages BEFORE one gets raised from partial trust.
            // If we don't do this, it will try to do so while in a partially trusted context,
            // and get into an chain of failed AssemblyResolve calls, ending in a failed Assert for "mscorlib recursive resource lookup bug".
            new ArgumentException();
        }

        [TestMethod]
        public void CreateInSandbox()
        {
            using (var Sandbox = new Sandbox())
            {
                var RemoteObject = Sandbox.Create<CreateInSandboxClass>();
                Assert.AreEqual("Hello", RemoteObject.SayHello());
            }
        }

        public sealed class CreateInSandboxClass : MarshalByRefObject
        {
            public string SayHello()
            {
                return "Hello";
            }
        }

        [TestMethod]
        public void ExecuteTaskInSandbox()
        {
            using (var Sandbox = new Sandbox())
            {
                var RemoteObject = Sandbox.Create<ExecuteTaskInSandboxClass>();

                RemoteObject.Execute();
            }
        }

        public sealed class ExecuteTaskInSandboxClass : MarshalByRefObject
        {
            public void Execute()
            {
                TestUtils.RunAsync(async () =>
                {
                    await TaskEx.Yield();
                });
            }
        }

        [TestMethod]
        public void ThrowTaskInSandbox()
        {
            using (var Sandbox = new Sandbox())
            {
                var RemoteObject = Sandbox.Create<ThrowTaskClass>();

                try
                {
                    RemoteObject.Execute();

                    Assert.Fail();
                }
                catch (InvalidOperationException e)
                {
                    Assert.AreEqual("Exception from Task", e.Message);
                }
            }
        }

        public sealed class ThrowTaskClass : MarshalByRefObject
        {
            public void Execute()
            {
                TestUtils.RunAsync(async () =>
                {
                    await TaskEx.Yield();

                    throw new InvalidOperationException("Exception from Task");
                });
            }
        }
    
        [TestMethod]
        public void ThrowNestedTask()
        {
            var RemoteObject = new ThrowNestedTaskClass();

            try
            {
                RemoteObject.Execute();

                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Exception from Task", e.Message);
            }
        }

        [TestMethod]
        public void ThrowNestedTaskInSandbox()
        {
            using (var Sandbox = new Sandbox())
            {
                var RemoteObject = Sandbox.Create<ThrowNestedTaskClass>();

                try
                {
                    RemoteObject.Execute();

                    Assert.Fail();
                }
                catch (InvalidOperationException e)
                {
                    Assert.AreEqual("Exception from Task", e.Message);
                }
            }
        }

        public sealed class ThrowNestedTaskClass : MarshalByRefObject
        {
            public void Execute()
            {
                TestUtils.RunAsync(async () =>
                {
                    await TaskEx.Run(async () =>
                    {
                        await TaskEx.Yield();

                        throw new InvalidOperationException("Exception from Task");
                    });
                });
            }
        }

        [TestMethod]
        public void ThrowCustomExceptionInSandbox()
        {
            using (var Sandbox = new Sandbox())
            {
                var RemoteObject = Sandbox.Create<ThrowCustomExceptionInSandboxClass>();

                try
                {
                    RemoteObject.Execute();

                    Assert.Fail();
                }
                catch (CustomException e)
                {
                    Assert.AreEqual("Exception from Task", e.Message);
                }
            }
        }

        public sealed class ThrowCustomExceptionInSandboxClass : MarshalByRefObject
        {
            public void Execute()
            {
                TestUtils.RunAsync(async () =>
                {
                    await TaskEx.Run(async () =>
                    {
                        await TaskEx.Yield();

                        throw new CustomException("Exception from Task");
                    });
                });
            }
        }

        [Serializable]
        public sealed class CustomException : Exception
        {
            public CustomException(string message) : base(message)
            {
            }

            public CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
#endif
}
