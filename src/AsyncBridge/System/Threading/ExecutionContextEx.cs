using System.Reflection;
using System.Security;

namespace System.Threading
{
    internal static class ExecutionContextEx
    {
#if NET20 || NET35
        public static readonly ExecutionContext Default =
            (ExecutionContext)typeof(ExecutionContext)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null)
                .Invoke(null);
#endif

#if !PORTABLE
        [SecurityCritical]
        private static ContextCallback preserveSynchronizationContextCallback;

        [SecurityCritical]
        private static void PreserveSynchronizationContextCallback(object state)
        {
            var tuple = (Tuple<ContextCallback, object, SynchronizationContext>)state;
            var callback = tuple.Item1;
            var callbackState = tuple.Item2;
            var preservedSynchronizationContext = tuple.Item3;

            var executionContextSyncronizationContext = SynchronizationContext.Current;
            if (preservedSynchronizationContext == executionContextSyncronizationContext)
            {
                callback.Invoke(callbackState);
                return;
            }

            SynchronizationContext.SetSynchronizationContext(preservedSynchronizationContext);
            try
            {
                callback.Invoke(callbackState);
            }
            finally
            {
                if (SynchronizationContext.Current == preservedSynchronizationContext)
                {
                    // ExecutionContext.Undo throws if the context is changed by the callback
                    SynchronizationContext.SetSynchronizationContext(executionContextSyncronizationContext);
                }
            }
        }
#endif

        [SecurityCritical]
        internal static void Run(ExecutionContext executionContext, ContextCallback callback, object state, bool preserveSyncCtx)
        {
#if PORTABLE
            ExecutionContext.Run(executionContext, callback, state);
#else
            if (!preserveSyncCtx)
            {
                ExecutionContext.Run(executionContext, callback, state);
                return;
            }

            if (preserveSynchronizationContextCallback == null)
                preserveSynchronizationContextCallback = PreserveSynchronizationContextCallback;

            preserveSynchronizationContextCallback.Invoke(Tuple.Create(callback, state, SynchronizationContext.Current));
#endif
        }
    }
}
