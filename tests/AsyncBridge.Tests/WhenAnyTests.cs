using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if !NET40
using TaskEx = System.Threading.Tasks.Task;
#endif

#if NET45
namespace ReferenceAsync.Tests
#elif ATP
namespace AsyncTargetingPack.Tests
#else
namespace AsyncBridge.Tests
#endif
{
    [TestClass]
    public class WhenAnyTests
    {
        [TestMethod]
        public void GenericArrayWithSomeContents()
        {
            TestUtils.RunAsync(async () =>
            {
                var taskCompletionSources = new[]
                {
                    new TaskCompletionSource<int>(),
                    new TaskCompletionSource<int>(),
                    new TaskCompletionSource<int>()
                };
                var whenAnyTask = TaskEx.WhenAny(Array.ConvertAll(taskCompletionSources, tcs => tcs.Task));
                taskCompletionSources[1].SetResult(2);
                var result = await whenAnyTask;
                Assert.AreEqual(2, await result);
            });
        }

        [TestMethod]
        public void GenericIEnumerableWithSomeContents()
        {
            TestUtils.RunAsync(async () =>
            {
                var taskCompletionSources = new[]
                {
                    new TaskCompletionSource<int>(),
                    new TaskCompletionSource<int>()
                };
                var whenAnyTask = TaskEx.WhenAny(Array.ConvertAll(taskCompletionSources, tcs => tcs.Task));
                taskCompletionSources[1].SetResult(2);
                var result = await whenAnyTask;
                Assert.AreEqual(2, await result);
            });
        }

        [TestMethod]
        public void EnumerableWithSomeContents()
        {
            TestUtils.RunAsync(async () =>
            {
                var taskCompletionSources = new[]
                {
                    new TaskCompletionSource<int>(),
                    new TaskCompletionSource<int>()
                };
                var whenAnyTask = TaskEx.WhenAny(Array.ConvertAll(taskCompletionSources, tcs => (Task)tcs.Task));
                Assert.IsFalse(whenAnyTask.IsCompleted);
                taskCompletionSources[1].SetResult(2);
                await await whenAnyTask;
            });
        }
    }
}
