using System;
using System.Threading;
using System.Threading.Tasks;

#if NET45
namespace ReferenceAsync.Tests
#elif ATP
namespace AsyncTargetingPack.Tests
#else
namespace AsyncBridge.Tests
#endif
{
    internal static class TestUtils
    {
        public static void RunAsync(Func<Task> asyncTestMethod)
        {
            if (asyncTestMethod == null) throw new ArgumentNullException(nameof(asyncTestMethod));
            asyncTestMethod.Invoke().GetAwaiter().GetResult();
        }

        public static TResult RunAsync<TResult>(Func<Task<TResult>> asyncTestMethod)
        {
            if (asyncTestMethod == null) throw new ArgumentNullException(nameof(asyncTestMethod));
            return asyncTestMethod.Invoke().GetAwaiter().GetResult();
        }

        public static void WaitWithoutInlining(Task task)
        {
            var awaiter = task.GetAwaiter();

            if (!awaiter.IsCompleted)
            {
                using (var mres = new ManualResetEventSlim())
                {
                    awaiter.OnCompleted(mres.Set);
                    mres.Wait();
                }
            }

            awaiter.GetResult();
        }
    }
}
