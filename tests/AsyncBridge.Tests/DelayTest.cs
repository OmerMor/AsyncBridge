using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncBridge.Tests
{
    [TestClass]
    public class DelayTest
    {
        [TestMethod]
        public async Task CheckItDoesReturn()
        {
            await TaskUtils.Delay(1);
        }

        [TestMethod]
        public async Task TimeSpanVersion()
        {
            await TaskUtils.Delay(TimeSpan.FromMilliseconds(1));
        }

        [TestMethod, ExpectedException(typeof(TaskCanceledException))]
        public async Task CancelImmediately()
        {
            CancellationToken cancellationToken = new CancellationToken(true);
            await TaskUtils.Delay(1, cancellationToken);
        }

        [TestMethod]
        public async Task ResiliantToGc()
        {
            bool keepGcing = true;
            Thread gcAllTheTime = new Thread(() => { while (keepGcing) GC.Collect(); });
            gcAllTheTime.Start();
            await TaskUtils.Delay(500);
            keepGcing = false;
        }
    }
}
