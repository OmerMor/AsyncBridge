using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// An awaitable which wraps a class, maybe preventing it from capturing the SynchronizationContext
    /// </summary>
    public class ConfigurableTaskAwaitable<T>
    {
        private readonly Task<T> m_task;
        private readonly bool m_useCapturedContext;

        public ConfigurableTaskAwaitable(Task<T> task, bool useCapturedContext)
        {
            m_task = task;
            m_useCapturedContext = useCapturedContext;
        }

        public TaskAwaiter<T> GetAwaiter()
        {
            return new TaskAwaiter<T>(m_task, m_useCapturedContext);
        }
    }

    // ZOMG why isn't void an actual type
    public class ConfigurableTaskAwaitable
    {
        private readonly Task m_task;
        private readonly bool m_useCapturedContext;

        public ConfigurableTaskAwaitable(Task task, bool useCapturedContext)
        {
            m_task = task;
            m_useCapturedContext = useCapturedContext;
        }

        public TaskAwaiter GetAwaiter()
        {
            return new TaskAwaiter(m_task, m_useCapturedContext);
        }
    }
}