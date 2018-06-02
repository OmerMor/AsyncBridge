#if NET20 || NET35
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Threading
{
    internal static class ThreadEx
    {
        private static Func<bool> yield;

        /// <summary>
        /// Causes the calling thread to yield execution to another thread that is ready to run on the current processor. The operating system selects the thread to yield to.
        /// </summary>
        public static bool Yield()
        {
            if (yield != null) return yield.Invoke();
            return YieldWithSetup(); // Extracted to make Yield inlinable
        }

        private static bool YieldWithSetup()
        {
            var bclMethod = typeof(Thread).GetMethod("Yield", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);
            if (bclMethod?.ReturnType == typeof(bool))
            {
                yield = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), bclMethod);
                return yield.Invoke();
            }

            try
            {
                var returnValue = SwitchToThread();
                yield = SwitchToThread;
                return returnValue;
            }
            catch (Exception ex) when (ex is DllNotFoundException || ex is EntryPointNotFoundException)
            {
            }

            try
            {
                var returnValue = LibCSchedYield();
                yield = LibCSchedYield;
                return returnValue;
            }
            catch (Exception ex) when (ex is DllNotFoundException || ex is EntryPointNotFoundException)
            {
            }

            try
            {
                var returnValue = LibSystemPthreadSchedYield();
                yield = LibSystemPthreadSchedYield;
                return returnValue;
            }
            catch (Exception ex) when (ex is DllNotFoundException || ex is EntryPointNotFoundException)
            {
            }

            throw new NotImplementedException("Support for Thread.Yield() on the current platform is not yet implemented.");
        }

        // If on Windows, use SwitchToThread.
        [DllImport("kernel32.dll")]
        private static extern bool SwitchToThread();

        // If on POSIX, use sched_yield.
        // https://github.com/dotnet/coreclr/blob/b8c69ed222a1e6e5392783cbb4df5faa87be349e/src/pal/src/thread/thread.cpp#L422-L446
        // https://github.com/mono/mono/blob/8eb8f7d5e74787049316fef1f4d09f2e9e2d6968/mono/utils/mono-threads-posix.c#L115-L119

        // Tested on ubuntu.14.04-x64
        [DllImport("libc.so.6", EntryPoint = "sched_yield")]
        private static extern bool LibCSchedYield();

        // Tested on osx.10.12-x64
        [DllImport("/usr/lib/system/libsystem_pthread.dylib", EntryPoint = "sched_yield")]
        private static extern bool LibSystemPthreadSchedYield();
    }
}
#endif
