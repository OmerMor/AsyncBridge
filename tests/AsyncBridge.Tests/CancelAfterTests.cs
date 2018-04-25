using System;
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
    [TestClass]
    public class CancelAfterTests
    {
        [TestMethod, ExpectedException(typeof(TaskCanceledException))]
        public void Cancel()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var Source = new CancellationTokenSource())
                {
                    Source.CancelAfter(10);

                    await TaskEx.Delay(100, Source.Token);
                }
            });
        }

        [TestMethod]
        public void NoCancel()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var Source = new CancellationTokenSource())
                {
                    Source.CancelAfter(50);
                }

                await TaskEx.Delay(100);
            });
        }
#if !ATP // Changing the CancelAfter time is not supported by the Async Targeting Pack
        [TestMethod]
        public void CancelChange()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var Source = new CancellationTokenSource())
                {
                    Source.CancelAfter(50);
                    Source.CancelAfter(1000);

                    await TaskEx.Delay(250);

                    Assert.IsFalse(Source.IsCancellationRequested);
                }
            });
        }

        [TestMethod]
        public void CancelRemove()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var Source = new CancellationTokenSource())
                {
                    Source.CancelAfter(50);
                    Source.CancelAfter(Timeout.Infinite);

                    await TaskEx.Delay(250);

                    Assert.IsFalse(Source.IsCancellationRequested);
                }
            });
        }
#endif
    }
}
