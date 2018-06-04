// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/src/System/Threading/Volatile.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT
// Docs supplemented from https://github.com/dotnet/dotnet-api-docs/blob/live/xml/System.Threading/Volatile.xml
// Docs under Creative Commons Attribution 4.0 International Public License https://github.com/dotnet/dotnet-api-docs/blob/live/LICENSE

// This comment below does not apply, but it is left in the spirit of making minimal alterations.
//
// > The VM will replace this with a more efficient implementation.

using System.Security;

namespace System.Threading
{
    //
    // Methods for accessing memory with volatile semantics.  These are preferred over Thread.VolatileRead
    // and Thread.VolatileWrite, as these are implemented more efficiently.
    //
    // (We cannot change the implementations of Thread.VolatileRead/VolatileWrite without breaking code
    // that relies on their overly-strong ordering guarantees.)
    //
    // The actual implementations of these methods are typically supplied by the VM at JIT-time, because C# does
    // not allow us to express a volatile read/write from/to a byref arg.
    // See getILIntrinsicImplementationForVolatile() in jitinterface.cpp.
    //
    /// <summary>Contains methods for performing volatile memory operations.</summary>
    public static class Volatile
    {
        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        public static bool Read(ref bool location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        [CLSCompliant(false)]
        public static sbyte Read(ref sbyte location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        public static byte Read(ref byte location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        public static short Read(ref short location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        [CLSCompliant(false)]
        public static ushort Read(ref ushort location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        public static int Read(ref int location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        [CLSCompliant(false)]
        public static uint Read(ref uint location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;

            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        public static long Read(ref long location)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile read
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            return Interlocked.CompareExchange(ref location, 0, 0);
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        [CLSCompliant(false)]
        [SecuritySafeCritical] // contains unsafe code
        public static ulong Read(ref ulong location)
        {
            unsafe
            {
                //
                // There is no overload of Interlocked.Exchange that accepts a ulong.  So we have
                // to do some pointer tricks to pass our arguments to the overload that takes a long.
                //
                fixed (ulong* pLocation = &location)
                {
                    return (ulong)Interlocked.CompareExchange(ref *(long*)pLocation, 0, 0);
                }
            }
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        public static IntPtr Read(ref IntPtr location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        [CLSCompliant(false)]
        public static UIntPtr Read(ref UIntPtr location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        public static float Read(ref float location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        /// <param name="location">The field to read.</param>
        /// <summary>Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The value that was read. This value is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
#if PORTABLE
        [SecuritySafeCritical] // contains unsafe code
#endif
        public static double Read(ref double location)
        {
#if PORTABLE
            unsafe
            {
                //
                // There is no overload of Interlocked.Exchange that accepts a double.  So we have
                // to do some pointer tricks to pass our arguments to the overload that takes a long.
                //
                fixed (double* pLocation = &location)
                {
                    var value = Interlocked.CompareExchange(ref *(long*)pLocation, 0, 0);
                    return *(double*)value;
                }
            }
#else
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile read
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            return Interlocked.CompareExchange(ref location, 0, 0);
#endif
        }

        /// <typeparam name="T">The type of field to read. This must be a reference type, not a value type.</typeparam>
        /// <param name="location">The field to read.</param>
        /// <summary>Reads the object reference from the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.</summary>
        /// <returns>The reference to <typeparamref name="T" /> that was read. This reference is the latest written by any processor in the computer, regardless of the number of processors or the state of processor cache.</returns>
        [SecuritySafeCritical] //the intrinsic implementation of this method contains unverifiable code
        public static T Read<T>(ref T location) where T : class
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }




        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        public static void Write(ref bool location, bool value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        [CLSCompliant(false)]
        public static void Write(ref sbyte location, sbyte value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        public static void Write(ref byte location, byte value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        public static void Write(ref short location, short value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        [CLSCompliant(false)]
        public static void Write(ref ushort location, ushort value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        public static void Write(ref int location, int value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        [CLSCompliant(false)]
        public static void Write(ref uint location, uint value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        public static void Write(ref long location, long value)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile write 
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            Interlocked.Exchange(ref location, value);
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        [CLSCompliant(false)]
        [SecuritySafeCritical] // contains unsafe code
        public static void Write(ref ulong location, ulong value)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile write 
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            unsafe
            {
                //
                // There is no overload of Interlocked.Exchange that accepts a ulong.  So we have
                // to do some pointer tricks to pass our arguments to the overload that takes a long.
                //
                fixed (ulong* pLocation = &location)
                {
                    Interlocked.Exchange(ref *(long*)pLocation, (long)value);
                }
            }
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        public static void Write(ref IntPtr location, IntPtr value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        [CLSCompliant(false)]
        public static void Write(ref UIntPtr location, UIntPtr value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        public static void Write(ref float location, float value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

        /// <param name="location">The field where the value is written.</param>
        /// <param name="value">The value to write. The value is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
#if PORTABLE
        [SecuritySafeCritical] // contains unsafe code
#endif
        public static void Write(ref double location, double value)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile write 
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
#if PORTABLE
            unsafe
            {
                //
                // There is no overload of Interlocked.Exchange that accepts a ulong.  So we have
                // to do some pointer tricks to pass our arguments to the overload that takes a long.
                //
                fixed (double* pLocation = &location)
                {
                    Interlocked.Exchange(ref *(long*)pLocation, *(long*)&value);
                }
            }
#else
            Interlocked.Exchange(ref location, value);
#endif
        }
        
        /// <typeparam name="T">The type of field to write. This must be a reference type, not a value type.</typeparam>
        /// <param name="location">The field where the object reference is written.</param>
        /// <param name="value">The object reference to write. The reference is written immediately so that it is visible to all processors in the computer.</param>
        /// <summary>Writes the specified object reference to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.</summary>
        [SecuritySafeCritical] //the intrinsic implementation of this method contains unverifiable code
        public static void Write<T>(ref T location, T value) where T : class
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }
    }
}
