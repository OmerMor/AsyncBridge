using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if NET45
using TaskEx = System.Threading.Tasks.Task;
#endif

//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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
    public class Tests
    {
        [TestMethod]
        public async Task AsyncTest()
        {
            var task = Task.Factory.StartNew(() => 4);
            var i = await task;

            Assert.AreEqual(4, i);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public async Task AsyncException()
        {
            var task = Task.Factory.StartNew<int>(() =>
            {
                throw new ApplicationException();
            });
            await task;
        }
    }
}