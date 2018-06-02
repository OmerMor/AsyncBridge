#if PORTABLE
using System.Linq;
using System.Reflection;

namespace System.Diagnostics
{
    internal static class Debug
    {
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Assert(bool condition)
        {
            Assert(condition, string.Empty);
        }

        private static readonly Action<bool, string> AssertAction = (Action<bool, string>)typeof(Debug)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .SingleOrDefault(method =>
            {
                if (method.Name != "Assert") return false;
                var parameters = method.GetParameters();
                return parameters.Length == 2 && parameters[0].ParameterType == typeof(bool) && parameters[1].ParameterType == typeof(string);
            })
            ?.CreateDelegate(typeof(Action<bool, string>));

        [System.Diagnostics.Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                AssertAction?.Invoke(false, message);
            }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public static void Fail(string message)
        {
            Assert(false, message);
        }
    }
}
#endif
