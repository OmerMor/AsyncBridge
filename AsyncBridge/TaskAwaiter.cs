using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
    public struct TaskAwaiter : INotifyCompletion
    {
        readonly Task task;

        internal TaskAwaiter(Task task)
        {
            this.task = task;
        }

        internal static TaskScheduler TaskScheduler
        {
            get
            {
                if (SynchronizationContext.Current == null)
                    return TaskScheduler.Default;
                else
                    return TaskScheduler.FromCurrentSynchronizationContext();
            }
        }

        public bool IsCompleted
        {
            get { return task.IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            this.task.ContinueWith(
                delegate(Task task)
                {
                    continuation();
                }, TaskAwaiter.TaskScheduler);
        }

        public void GetResult()
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions[0];
            }
        }
    }

    public struct TaskAwaiter<T> : INotifyCompletion
    {
        readonly Task<T> task;

        internal TaskAwaiter(Task<T> task)
        {
            this.task = task;
        }

        public bool IsCompleted
        {
            get { return task.IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            this.task.ContinueWith(
                delegate(Task<T> task)
                {
                    continuation();
                }, TaskAwaiter.TaskScheduler);
        }

        public T GetResult()
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions[0];
            }
        }
    }
}