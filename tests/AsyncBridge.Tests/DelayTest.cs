using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if !NET40
using TaskEx = System.Threading.Tasks.Task;
#endif

#if NET45
namespace ReferenceAsync.Tests
#elif ATP
namespace AsyncTargetingPack.Tests
#else
namespace AsyncBridge.Tests
#endif
{
    [TestClass]
    public class DelayTest
    {
        [TestMethod]
        public void CheckItDoesReturn()
        {
            TestUtils.RunAsync(async () =>
            {
                await TaskEx.Delay(1);
            });
        }

        [TestMethod]
        public void TimeSpanVersion()
        {
            TestUtils.RunAsync(async () =>
            {
                await TaskEx.Delay(TimeSpan.FromMilliseconds(1));
            });
        }

        [TestMethod, ExpectedException(typeof (TaskCanceledException))]
        public void CancelImmediately()
        {
            TestUtils.RunAsync(async () =>
            {
                var cancellationToken = new CancellationToken(true);
                await TaskEx.Delay(1, cancellationToken);
            });
        }

        [TestMethod]
        public void ResiliantToGc()
        {
            TestUtils.RunAsync(async () =>
            {
                var keepGcing = true;

                var gcAllTheTime = new Thread(() =>
                {
                    // ReSharper disable AccessToModifiedClosure
                    while (keepGcing)
                    // ReSharper restore AccessToModifiedClosure
                    {
                        GC.Collect();
                        Thread.Sleep(1);
                    }
                });

                gcAllTheTime.Start();
                await TaskEx.Delay(500);
                keepGcing = false;
            });
        }
    }
}
