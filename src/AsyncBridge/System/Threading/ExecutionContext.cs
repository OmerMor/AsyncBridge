#if PORTABLE

namespace System.Threading
{
    internal class ExecutionContext : IDisposable
    {
        internal static ExecutionContext Capture()
        {
            return null;
        }

        internal static void Run(ExecutionContext executionContext, ContextCallback callback, object state)
        {
            callback(state);
        }

        public void Dispose()
        {
        }
    }

    internal delegate void ContextCallback(object state);
}

#endif
