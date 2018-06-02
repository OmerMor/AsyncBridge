#if NET20 || NET35
using System.Reflection;

namespace System.Threading
{
    internal static class ExecutionContextEx
    {
        public static readonly ExecutionContext Default =
            (ExecutionContext)typeof(ExecutionContext)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null)
                .Invoke(null);
    }
}
#endif
