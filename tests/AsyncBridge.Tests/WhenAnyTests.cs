using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncBridge.Tests
{
    [TestClass]
    public class WhenAnyTests
    {
        [TestMethod]
        public async Task GenericArrayWithSomeContents()
        {
            var taskCompletionSources = new []
                                        {
                                            new TaskCompletionSource<int>(),
                                            new TaskCompletionSource<int>(),
                                            new TaskCompletionSource<int>()
                                        };
            var whenAnyTask = TaskUtils.WhenAny(taskCompletionSources.Select(tcs => tcs.Task).ToArray());
            taskCompletionSources[1].SetResult(2);
            var result = await whenAnyTask;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public async Task GenericIEnumerableWithSomeContents()
        {
            var taskCompletionSources = new []
                                        {
                                            new TaskCompletionSource<int>(),
                                            new TaskCompletionSource<int>()
                                        };
            var whenAnyTask = TaskUtils.WhenAny(taskCompletionSources.Select(tcs => tcs.Task));
            taskCompletionSources[1].SetResult(2);
            var result = await whenAnyTask;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public async Task EnumerableWithSomeContents()
        {
            var taskCompletionSources = new []
                                        {
                                            new TaskCompletionSource<int>(),
                                            new TaskCompletionSource<int>()
                                        };
            var whenAnyTask = TaskUtils.WhenAny(taskCompletionSources.Select(tcs => tcs.Task).Cast<Task>());
            Assert.IsFalse(whenAnyTask.IsCompleted);
            taskCompletionSources[1].SetResult(2);
            await whenAnyTask;
        }
    }
}