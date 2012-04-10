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
            List<TaskCompletionSource<int>> taskCompletionSources = new List<TaskCompletionSource<int>>
                                                                    {
                                                                        new TaskCompletionSource<int>(),
                                                                        new TaskCompletionSource<int>(),
                                                                        new TaskCompletionSource<int>()
                                                                    };
            Task<IEnumerable<int>> whenAllTask = TaskUtils.WhenAll(taskCompletionSources.Select(tcs => tcs.Task));
            taskCompletionSources[0].SetResult(1);
            taskCompletionSources[1].SetResult(2);
            taskCompletionSources[2].SetResult(3);
            IEnumerable<int> results = await whenAllTask;
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, results.ToList());
        }

        [TestMethod]
        public void DontCompleteOne()
        {
            List<TaskCompletionSource<int>> taskCompletionSources = new List<TaskCompletionSource<int>>
                                                                    {new TaskCompletionSource<int>(), new TaskCompletionSource<int>()};
            Task<IEnumerable<int>> whenAllTask = TaskUtils.WhenAll(taskCompletionSources.Select(tcs => tcs.Task));
            taskCompletionSources[0].SetResult(1);
            Assert.IsFalse(whenAllTask.IsCompleted);
        }

        [TestMethod]
        public async Task NonGenericVersion()
        {
            List<TaskCompletionSource<int>> taskCompletionSources = new List<TaskCompletionSource<int>> { new TaskCompletionSource<int>(), new TaskCompletionSource<int>() };
            Task whenAllTask = TaskUtils.WhenAll(taskCompletionSources.Select(tcs => (Task)tcs.Task));
            taskCompletionSources[0].SetResult(1);
            Assert.IsFalse(whenAllTask.IsCompleted);
            taskCompletionSources[1].SetResult(1);
            await whenAllTask;
        }

        [TestMethod]
        public async Task ArrayVersion()
        {
            List<TaskCompletionSource<int>> taskCompletionSources = new List<TaskCompletionSource<int>> { new TaskCompletionSource<int>(), new TaskCompletionSource<int>() };
            Task whenAllTask = TaskUtils.WhenAll(taskCompletionSources.Select(tcs => tcs.Task).ToArray());
            taskCompletionSources[0].SetResult(1);
            Assert.IsFalse(whenAllTask.IsCompleted);
            taskCompletionSources[1].SetResult(1);
            await whenAllTask;
        }
    }
}