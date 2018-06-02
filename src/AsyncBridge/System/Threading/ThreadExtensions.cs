using System.Reflection;

namespace System.Threading
{
    internal static class ThreadExtensions
    {
        private static readonly Action<Thread, ExecutionContext> SetExecutionContextDelegate = (Action<Thread, ExecutionContext>)
            typeof(Thread)
            .GetMethod("SetExecutionContext", BindingFlags.NonPublic | BindingFlags.Instance)
            .CreateDelegate(typeof(Action<Thread, ExecutionContext>));

        public static void SetExecutionContext(this Thread thread, ExecutionContext value)
        {
            SetExecutionContextDelegate.Invoke(thread, value);
        }
    }
}
