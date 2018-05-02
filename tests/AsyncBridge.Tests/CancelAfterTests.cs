using System;
using System.Linq;
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
                using (var cancelSource = new CancellationTokenSource())
                {
                    cancelSource.CancelAfter(10);

                    await TaskEx.Delay(100, cancelSource.Token);
                }
            });
        }

        [TestMethod]
        public void NoCancel()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var cancelSource = new CancellationTokenSource())
                {
                    cancelSource.CancelAfter(50);
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
                using (var cancelSource = new CancellationTokenSource())
                {
                    cancelSource.CancelAfter(50);
                    cancelSource.CancelAfter(1000);

                    await TaskEx.Delay(250);

                    Assert.IsFalse(cancelSource.IsCancellationRequested);
                }
            });
        }

        [TestMethod]
        public void CancelRemove()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var cancelSource = new CancellationTokenSource())
                {
                    cancelSource.CancelAfter(50);
                    cancelSource.CancelAfter(Timeout.Infinite);

                    await TaskEx.Delay(250);

                    Assert.IsFalse(cancelSource.IsCancellationRequested);
                }
            });
        }

        [TestMethod]
        public void CancelConcurrentNew()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var cancelSource = new CancellationTokenSource())
                {
                    var continueSource = new TaskCompletionSource<bool>();

                    // Spawn ten threads to create an immediate timer
                    var cancelTasks = Enumerable.Range(0, 10).Select(async (index) =>
                    {
                        await continueSource.Task;

                        cancelSource.CancelAfter(0);
                    });
                
                    // Queue them all to run at once
                    continueSource.SetResult(true);

                    await TaskEx.WhenAll(cancelTasks);

                    var spin = new SpinWait();

                    while (!cancelSource.IsCancellationRequested)
                        spin.SpinOnce();
                }
            });
        }
        [TestMethod]
        public void CancelConcurrentExisting()
        {
            TestUtils.RunAsync(async () =>
            {
                using (var cancelSource = new CancellationTokenSource())
                {
                    // Create the timer first
                    cancelSource.CancelAfter(Timeout.Infinite);

                    var continueSource = new TaskCompletionSource<bool>();

                    // Spawn ten threads to set the timer to immediate
                    var cancelTasks = Enumerable.Range(0, 10).Select(async (index) =>
                    {
                        await continueSource.Task;

                        cancelSource.CancelAfter(0);
                    });

                    // Queue them all to run at once
                    continueSource.SetResult(true);

                    await TaskEx.WhenAll(cancelTasks);

                    var spin = new SpinWait();

                    while (!cancelSource.IsCancellationRequested)
                        spin.SpinOnce();
                }
            });
        }
#endif
    }
}
