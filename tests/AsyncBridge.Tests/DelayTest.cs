using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            await TaskUtils.Delay(0);
        }
    }
}
