using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AsyncBridge.Tests
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