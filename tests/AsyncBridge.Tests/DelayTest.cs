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
    public class DelayTest
    {
        [TestMethod]
        public async Task CheckItDoesReturn()
        {
            await TaskEx.Delay(1);
        }

        [TestMethod]
        public async Task TimeSpanVersion()
        {
            await TaskEx.Delay(TimeSpan.FromMilliseconds(1));
        }

        [TestMethod, ExpectedException(typeof (TaskCanceledException))]
        public async Task CancelImmediately()
        {
            var cancellationToken = new CancellationToken(true);
            await TaskEx.Delay(1, cancellationToken);
        }

        [TestMethod]
        public async Task ResiliantToGc()
        {
            var keepGcing = true;
            // ReSharper disable AccessToModifiedClosure
            var gcAllTheTime = new Thread(() => { while (keepGcing) GC.Collect(); });
            // ReSharper restore AccessToModifiedClosure
            gcAllTheTime.Start();
            await TaskEx.Delay(500);
            keepGcing = false;
        }
    }
}