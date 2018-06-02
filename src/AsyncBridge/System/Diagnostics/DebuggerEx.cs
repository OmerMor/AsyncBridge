using System.Reflection;

namespace System.Diagnostics
{
    internal static class DebuggerEx
    {
#if NET35 || PORTABLE
        private static readonly Action NotifyOfCrossThreadDependencyAction = (Action)typeof(Debugger)
#if PORTABLE
            .GetMethod("NotifyOfCrossThreadDependency", new Type[0])
#else
            .GetMethod("NotifyOfCrossThreadDependency", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null)
#endif
            ?.CreateDelegate(typeof(Action));

        public static void NotifyOfCrossThreadDependency()
        {
            NotifyOfCrossThreadDependencyAction?.Invoke();
        }
#else
        public static void NotifyOfCrossThreadDependency()
        {
            Debugger.NotifyOfCrossThreadDependency();
        }
#endif
    }
}
