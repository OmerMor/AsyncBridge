using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct YieldAwaitable
    {
        private readonly object m_target;

        internal YieldAwaitable(object target)
        {
            m_target = target;
        }
        
        public YieldAwaiter GetAwaiter()
        {
            return new YieldAwaiter(m_target);
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct YieldAwaiter : ICriticalNotifyCompletion, INotifyCompletion
        {
            private static readonly WaitCallback s_waitCallbackRunAction = runAction;
            private static readonly SendOrPostCallback s_sendOrPostCallbackRunAction =
                runAction;
            private readonly object m_target;

            internal YieldAwaiter(object target)
            {
                m_target = target;
            }

            public bool IsCompleted
            {
                get { return false; }
            }

            static YieldAwaiter()
            {
            }

            [SecuritySafeCritical]
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            public void OnCompleted(Action continuation)
            {
                queueContinuation(continuation, true);
            }

            [SecurityCritical]
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            public void UnsafeOnCompleted(Action continuation)
            {
                queueContinuation(continuation, false);
            }

            [SecurityCritical]
            private void queueContinuation(Action continuation, bool flowContext)
            {
                if (continuation == null)
                    throw new ArgumentNullException("continuation");

                if (m_target == null)
                    throw new InvalidOperationException("The awaitable was not properly initialized.");

                var synchronizationContext = m_target as SynchronizationContext;
                if (synchronizationContext != null)
                {
                    synchronizationContext.Post(s_sendOrPostCallbackRunAction, continuation);
                }
                else
                {
                    var scheduler = (TaskScheduler)m_target;
                    if (scheduler == TaskScheduler.Default)
                    {
                        if (flowContext)
                            ThreadPool.QueueUserWorkItem(s_waitCallbackRunAction, continuation);
                        else
                            ThreadPool.UnsafeQueueUserWorkItem(s_waitCallbackRunAction, continuation);
                    }
                    else
                    {
                        Task.Factory.StartNew(continuation, CancellationToken.None, TaskCreationOptions.PreferFairness,
                                              scheduler);}
                }
            }

            public void GetResult()
            {
            }

            private static void runAction(object state)
            {
                ((Action) state)();
            }
        }
    }
}