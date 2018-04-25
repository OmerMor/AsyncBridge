using System;
using System.Threading.Tasks;

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
    internal static class TestUtils
    {
        public static void RunAsync(Func<Task> asyncTestMethod)
        {
            if (asyncTestMethod == null) throw new ArgumentNullException(nameof(asyncTestMethod));
            asyncTestMethod.Invoke().GetAwaiter().GetResult();
        }
    }
}
