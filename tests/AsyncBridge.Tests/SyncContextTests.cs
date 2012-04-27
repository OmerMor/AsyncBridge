using System;
using System.Diagnostics;
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
    public static class Write
    {
        public static void Line(string line)
        {
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + getContext() + ": " + line);
        }

        private static string getContext()
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
        public async Task YieldSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            await TaskEx.Yield();
            Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
        }

        [TestMethod]
        public async Task FromResultSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            int r = await TaskEx.FromResult(4);
            Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            Assert.AreEqual(4, r);
        }


        [TestMethod]
        public void DelaySyncContext_wrapped()
        {
            var t = DelaySyncContext();
            t.Wait();
        }

        [TestMethod, Ignore]
        public void NotCapturedReturningTaskSyncContext_wrapped()
        {
            var t = NotCapturedReturningTaskSyncContext();
            t.Wait();
        }

        [TestMethod, Ignore]
        public void NotCapturedSimpleTaskSyncContext_wrapped()
        {
            var t = NotCapturedSimpleTaskSyncContext();
            t.Wait();
        }
        [TestMethod]
        public void CapturedSimpleTaskSyncContext_wrapped()
        {
            var t = CapturedSimpleTaskSyncContext();
            t.Wait();
        }


        [TestMethod]
        public async Task DelaySyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            await TaskEx.Delay(10);
            Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
        }

        [TestMethod]
        public async Task SimpleTaskSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            await WaitABit();
            Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
        }

        [TestMethod]
        public async Task ReturningTaskSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            int r = await WaitAThing();
            Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            Assert.AreEqual(6, r);
        }

        [TestMethod, Ignore]
        public async Task NotCapturedSimpleTaskSyncContext()
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
        }
        [TestMethod]
        public async Task CapturedSimpleTaskSyncContext()
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
        }

        [TestMethod]
        public async Task CapturedReturningTaskSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            int r = await TaskEx.Run(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(WickedSynchronizationContext.Instance);
                return await WaitAThing();
            }).ConfigureAwait(true);

            Assert.AreSame(SynchronizationContext.Current, MagicSynchronizationContext.Instance);
            Assert.AreEqual(6, r);
        }

        [TestMethod, Ignore]
        public async Task NotCapturedReturningTaskSyncContext()
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