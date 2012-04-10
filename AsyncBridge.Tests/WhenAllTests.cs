using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AsyncBridge.Tests
{
    [TestClass]
    public class WhenAllTests
    {
        [TestMethod]
        public async Task GenericIEnumerableWithSomeContents()
        {
            List<TaskCompletionSource<int>> taskCompletionSources = new List<TaskCompletionSource<int>>();
            taskCompletionSources.Add(new TaskCompletionSource<int>());
            taskCompletionSources.Add(new TaskCompletionSource<int>());
            taskCompletionSources.Add(new TaskCompletionSource<int>());
            Task<IEnumerable<int>> whenAllTask = TaskUtils.WhenAll(taskCompletionSources.Select(tcs => tcs.Task));
            taskCompletionSources[0].SetResult(1);
            taskCompletionSources[1].SetResult(2);
            taskCompletionSources[2].SetResult(3);
            IEnumerable<int> results = await whenAllTask;
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, results.ToList());
        }

        [TestMethod]
        public async Task DontCompleteOne()
        {
            List<TaskCompletionSource<int>> taskCompletionSources = new List<TaskCompletionSource<int>>();
            taskCompletionSources.Add(new TaskCompletionSource<int>());
            taskCompletionSources.Add(new TaskCompletionSource<int>());
            Task<IEnumerable<int>> whenAllTask = TaskUtils.WhenAll(taskCompletionSources.Select(tcs => tcs.Task));
            taskCompletionSources[0].SetResult(1);
            Assert.IsFalse(whenAllTask.IsCompleted);
        }
    }
}