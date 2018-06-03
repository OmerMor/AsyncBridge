using System;
using System.Diagnostics;
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
    public static class Write
    {
        public static void Line(string line)
        {
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + GetContext() + ": " + line);
        }

        private static string GetContext()
        {
            var context = SynchronizationContext.Current;
            return context == null ? "null" : context.GetType().Name;
        }
    }
    [TestClass]
    public class SyncContextTests
    {
        class WickedSynchronizationContext : SynchronizationContext
        {
            public static readonly WickedSynchronizationContext Instance = new WickedSynchronizationContext();

            public override void Post(SendOrPostCallback callback, object state)
            {
                Write.Line("WickedSynchronizationContext.Post");
                base.Post(s =>
                {
                    SetSynchronizationContext(this);
                    callback(s);
                }, state);
            }

            public override SynchronizationContext CreateCopy()
            {
                Write.Line("WickedSynchronizationContext.CreateCopy");
                return Instance;
            }
        }

        class MagicSynchronizationContext : SynchronizationContext
        {
            public static readonly MagicSynchronizationContext Instance = new MagicSynchronizationContext();

            public override void Post(SendOrPostCallback callback, object state)
            {
                Write.Line("MagicSynchronizationContext.Post");
                base.Post(s =>
                {
                    SetSynchronizationContext(this);
                    callback(s);
                }, state);
            }

            public override SynchronizationContext CreateCopy()
            {
                Write.Line("MagicSynchronizationContext.CreateCopy");
                return Instance;
            }
        }

        [TestMethod]
        public void YieldSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                await TaskEx.Yield();
                Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            });
        }

        [TestMethod]
        public void FromResultSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                int r = await TaskEx.FromResult(4);
                Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
                Assert.AreEqual(4, r);
            });
        }

        [TestMethod]
        public void DelaySyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                await TaskEx.Delay(10);
                Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            });
        }

        [TestMethod]
        public void SimpleTaskSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                await WaitABit();
                Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            });
        }

        [TestMethod]
        public void ReturningTaskSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                int r = await WaitAThing();
                Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
                Assert.AreEqual(6, r);
            });
        }

        private sealed class SpySynchronizationContext : SynchronizationContext
        {
            public bool WasUsed { get; private set; }

            public override void Post(SendOrPostCallback d, object state)
            {
                WasUsed = true;
                base.Post(d, state);
            }
        }

        [TestMethod]
#if ATP
        [Ignore]
#endif
        public void ConfigureAwaitFalse()
        {
            var spyContext = new SpySynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(spyContext);

            var source = new TaskCompletionSource<object>();
            var configuredTaskAwaiter = source.Task.ConfigureAwait(false).GetAwaiter();

            using (var waitForFinish = new CountdownEvent(4))
            {
                // Register continuations before the task is complete
                configuredTaskAwaiter.UnsafeOnCompleted(() => waitForFinish.Signal());
                configuredTaskAwaiter.OnCompleted(() => waitForFinish.Signal());

                // Complete the task
                source.SetResult(null);

                // Register continuations after the task is complete
                configuredTaskAwaiter.UnsafeOnCompleted(() => waitForFinish.Signal());
                configuredTaskAwaiter.OnCompleted(() => waitForFinish.Signal());

                // Make sure all four continuations have finished running
                waitForFinish.Wait();

                // Check whether the continuations ran via the spy synchronization context
                Assert.IsFalse(spyContext.WasUsed);
            }
        }

        [TestMethod, Ignore]
        public void NotCapturedSimpleTaskSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                Write.Line("START");
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                await TaskEx.Run(async () =>
                {
                    Write.Line("A");
                    SynchronizationContext.SetSynchronizationContext(WickedSynchronizationContext.Instance);
                    Write.Line("B");
                    await WaitABit();
                    Write.Line("C");
                }).ConfigureAwait(false);
                Write.Line("END");
                Assert.AreNotSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            });
        }

        [TestMethod]
        public void CapturedSimpleTaskSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                Write.Line("START");
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                await TaskEx.Run(async () =>
                {
                    Write.Line("A");
                    SynchronizationContext.SetSynchronizationContext(WickedSynchronizationContext.Instance);
                    Write.Line("B");
                    await WaitABit();
                    Write.Line("C");
                }).ConfigureAwait(true);
                Write.Line("END");
                Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            });
        }

        [TestMethod]
        public void CapturedReturningTaskSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                int r = await TaskEx.Run(async () =>
                {
                    SynchronizationContext.SetSynchronizationContext(WickedSynchronizationContext.Instance);
                    return await WaitAThing();
                }).ConfigureAwait(true);

                Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
                Assert.AreEqual(6, r);
            });
        }

        [TestMethod, Ignore]
        public void NotCapturedReturningTaskSyncContext()
        {
            TestUtils.RunAsync(async () =>
            {
                Write.Line("START");
                SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
                int r = await TaskEx.Run(async () =>
                {
                    Write.Line("A");
                    SynchronizationContext.SetSynchronizationContext(WickedSynchronizationContext.Instance);
                    Write.Line("B");
                    var result = await WaitAThing();
                    Write.Line("C");
                    return result;
                }).ConfigureAwait(false);
                Write.Line("END");
                Assert.AreNotSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
                Assert.AreEqual(6, r);
            });
        }

        private sealed class CopyableSynchronizationContext : SynchronizationContext
        {
            public override SynchronizationContext CreateCopy()
            {
                return new CopyableSynchronizationContext();
            }
        }

#if !ATP
        [TestMethod]
        public void TaskRunShouldNotFlowCapturedSyncContextWhenInlined()
        {
            SynchronizationContext.SetSynchronizationContext(null);

            // Captured null
            var task = Task.Factory.StartNew(
                () => Assert.IsInstanceOfType(SynchronizationContext.Current, typeof(CopyableSynchronizationContext)),
                CancellationToken.None,
                TaskCreationOptions.None,
                new InliningScheduler());

            var copyableContext = new CopyableSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(copyableContext);

            // Should execute with copyableContext
            task.GetAwaiter().GetResult();
        }
#endif

        [TestMethod]
        public void TaskRunShouldNotFlowCapturedSyncContextWhenNotInlined()
        {
            var copyableContext = new CopyableSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(copyableContext);

            // Captured copyableContext, should execute with threadpool default context
            var task = TaskEx.Run(
                () => Assert.IsNotInstanceOfType(SynchronizationContext.Current, typeof(CopyableSynchronizationContext)));

            TestUtils.WaitWithoutInlining(task);
        }

        [TestMethod]
        public void ContinueWithShouldNotFlowCapturedSyncContextWhenInlined()
        {
            SynchronizationContext.SetSynchronizationContext(null);

            // Captured null
            var task = TaskEx.FromResult<object>(null).ContinueWith(
                _ => Assert.IsInstanceOfType(SynchronizationContext.Current, typeof(CopyableSynchronizationContext)),
                new InliningScheduler());

            var copyableContext = new CopyableSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(copyableContext);

            // Should execute with copyableContext
            task.GetAwaiter().GetResult();
        }

        [TestMethod]
        public void ContinueWithShouldNotFlowCapturedSyncContextWhenNotInlined()
        {
            var copyableContext = new CopyableSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(copyableContext);

            // Captured copyableContext, should execute with threadpool default context
            var task = TaskEx.FromResult<object>(null).ContinueWith(
                _ => Assert.IsNotInstanceOfType(SynchronizationContext.Current, typeof(CopyableSynchronizationContext)));

            TestUtils.WaitWithoutInlining(task);
        }

        /// <summary>
        /// Exercise our AsyncTaskMethodBuilder
        /// </summary>
        private async Task WaitABit()
        {
            await TaskEx.Delay(10);
        }

        /// <summary>
        /// Exercise our AsyncTaskMethodBuilder'1
        /// </summary>
        private async Task<int> WaitAThing()
        {
            await TaskEx.Delay(10);
            return await TaskEx.FromResult(6);
        }
    }
}
