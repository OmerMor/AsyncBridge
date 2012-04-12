using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
    public struct TaskAwaiter : INotifyCompletion
    {
        private readonly Task m_task;
        private readonly bool m_useCapturedContext;

        internal TaskAwaiter(Task task, bool useCapturedContext = true)
        {
            m_task = task;
            m_useCapturedContext = useCapturedContext;
        }

        internal static TaskScheduler TaskScheduler
        {
            get
            {
                var taskScheduler = SynchronizationContext.Current == null
                                        ? TaskScheduler.Current
                                        : TaskScheduler.FromCurrentSynchronizationContext();
                return taskScheduler;
            }
        }

        public bool IsCompleted
        {
            get { return m_task.IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            m_task.ContinueWith(
                delegate { continuation(); },
                // I don't think continuing on the thread pool is what people really wanted when they called ConfigureAwait, but it's what the CTP did
                m_useCapturedContext ? TaskScheduler : TaskScheduler.Default);
        }

        public void GetResult()
        {
            try
            {
                m_task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions[0];
            }
        }
    }

    public struct TaskAwaiter<T> : INotifyCompletion
    {
        private readonly Task<T> m_task;
        private readonly bool m_useCapturedContext;

        public TaskAwaiter(Task<T> task, bool useCapturedContext = true)
        {
            m_task = task;
            m_useCapturedContext = useCapturedContext;
        }

        public bool IsCompleted
        {
            get { return m_task.IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            m_task.ContinueWith(
                delegate { continuation(); },
                // I don't think continuing on the thread pool is what people really wanted when they called ConfigureAwait, but it's what the CTP did
                m_useCapturedContext ? TaskAwaiter.TaskScheduler : TaskScheduler.Default);
        }

        public T GetResult()
        {
            try
            {
                return m_task.Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions[0];
            }
        }
    }
}