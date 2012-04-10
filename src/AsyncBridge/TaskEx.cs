namespace System.Threading.Tasks
{
    public static class TaskEx
    {
        public static TaskAwaiter GetAwaiter(this Task task)
        {
            return new TaskAwaiter(task);
        }

        public static TaskAwaiter<T> GetAwaiter<T>(this Task<T> task)
        {
            return new TaskAwaiter<T>(task);
        }
    }
}