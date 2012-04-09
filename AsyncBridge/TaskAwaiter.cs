using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
    public struct TaskAwaiter : INotifyCompletion
    {
        private readonly Task m_task;

        internal TaskAwaiter(Task task)
        {
            m_task = task;
        }

        internal static TaskScheduler TaskScheduler
        {
            get
            {
                var taskScheduler = SynchronizationContext.Current == null
                                        ? TaskScheduler.Default
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
                delegate { continuation(); }, TaskScheduler);
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

        internal TaskAwaiter(Task<T> task)
        {
            m_task = task;
        }

        public bool IsCompleted
        {
            get { return m_task.IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            m_task.ContinueWith(
                delegate { continuation(); }, TaskAwaiter.TaskScheduler);
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