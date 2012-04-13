using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncBridge.Tests
{
    [TestClass]
    public class SyncContextTests
    {
        class MagicSynchronizationContext : SynchronizationContext
        {
            public static readonly MagicSynchronizationContext Instance = new MagicSynchronizationContext();

            public override void Post(SendOrPostCallback d, object state)
            {
                base.Post(o =>
                {
                    SetSynchronizationContext(this);
                    d(o);
                }, state);
            }
        }

        [TestMethod]
        public async Task YieldSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            await TaskUtils.Yield();
            Assert.IsTrue(SynchronizationContext.Current is MagicSynchronizationContext);
        }

        [TestMethod]
        public async Task FromResultSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            int r = await TaskUtils.FromResult(4);
            Assert.IsTrue(SynchronizationContext.Current is MagicSynchronizationContext);
            Assert.AreEqual(4, r);
        }

        [TestMethod]
        public async Task DelaySyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            await TaskUtils.Delay(1);
            Assert.IsTrue(SynchronizationContext.Current is MagicSynchronizationContext);
        }

        [TestMethod]
        public async Task SimpleTaskSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            await WaitABit();
            Assert.IsTrue(SynchronizationContext.Current is MagicSynchronizationContext);
        }

        [TestMethod]
        public async Task ReturningTaskSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            int r = await WaitAThing();
            Assert.IsTrue(SynchronizationContext.Current is MagicSynchronizationContext);
            Assert.AreEqual(6, r);
        }

        [TestMethod]
        public async Task ConfiguredSimpleTaskSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            await WaitABit().ConfigureAwait(false);
            Assert.IsFalse(SynchronizationContext.Current is MagicSynchronizationContext);
        }

        [TestMethod]
        public async Task ConfiguredReturningTaskSyncContext()
        {
            SynchronizationContext.SetSynchronizationContext(MagicSynchronizationContext.Instance);
            int r = await WaitAThing().ConfigureAwait(false);
            Assert.IsFalse(SynchronizationContext.Current is MagicSynchronizationContext);
            Assert.AreEqual(6, r);
        }

        /// <summary>
        /// Exercise our AsyncTaskMethodBuilder
        /// </summary>
        private async Task WaitABit()
        {
            await TaskUtils.Delay(1);
        }

        /// <summary>
        /// Exercise our AsyncTaskMethodBuilder'1
        /// </summary>
        private async Task<int> WaitAThing()
        {
            await TaskUtils.Delay(1);
            return await TaskUtils.FromResult(6);
        }
    }
}