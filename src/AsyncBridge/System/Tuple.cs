// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/shared/System/Tuple.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT

#if NET35
using System.Collections.Generic;
using System.Text;

//
// Note: F# compiler depends on the exact tuple hashing algorithm. Do not ever change it.
//

namespace System
{
    internal static class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }

        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }

        // From System.Web.Util.HashCodeCombiner
        internal static int CombineHashCodes(int h1, int h2)
        {
            return (((h1 << 5) + h1) ^ h2);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), h3);
        }
    }

    [Serializable]
    internal class Tuple<T1, T2> : IComparable
    {
        private readonly T1 m_Item1; // Do not rename (binary serialization)
        private readonly T2 m_Item2; // Do not rename (binary serialization)

        public T1 Item1 { get { return m_Item1; } }
        public T2 Item2 { get { return m_Item2; } }

        public Tuple(T1 item1, T2 item2)
        {
            m_Item1 = item1;
            m_Item2 = item2;
        }

        public override Boolean Equals(Object obj)
        {
            if (obj == null) return false;

            Tuple<T1, T2> objTuple = obj as Tuple<T1, T2>;

            if (objTuple == null)
            {
                return false;
            }

            return EqualityComparer<Object>.Default.Equals(m_Item1, objTuple.m_Item1)
                && EqualityComparer<Object>.Default.Equals(m_Item2, objTuple.m_Item2);
        }

        Int32 IComparable.CompareTo(Object obj)
        {
            if (obj == null) return 1;

            Tuple<T1, T2> objTuple = obj as Tuple<T1, T2>;

            if (objTuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, this.GetType().ToString()), nameof(obj));
            }

            int c = 0;

            c = Comparer<Object>.Default.Compare(m_Item1, objTuple.m_Item1);

            if (c != 0) return c;

            return Comparer<Object>.Default.Compare(m_Item2, objTuple.m_Item2);
        }

        public override int GetHashCode()
        {
            return Tuple.CombineHashCodes(
                EqualityComparer<Object>.Default.GetHashCode(m_Item1),
                EqualityComparer<Object>.Default.GetHashCode(m_Item2));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    internal class Tuple<T1, T2, T3> : IComparable
    {
        private readonly T1 m_Item1; // Do not rename (binary serialization)
        private readonly T2 m_Item2; // Do not rename (binary serialization)
        private readonly T3 m_Item3; // Do not rename (binary serialization)

        public T1 Item1 { get { return m_Item1; } }
        public T2 Item2 { get { return m_Item2; } }
        public T3 Item3 { get { return m_Item3; } }

        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
        }

        public override Boolean Equals(Object obj)
        {
            if (obj == null) return false;

            Tuple<T1, T2, T3> objTuple = obj as Tuple<T1, T2, T3>;

            if (objTuple == null)
            {
                return false;
            }

            return EqualityComparer<Object>.Default.Equals(m_Item1, objTuple.m_Item1)
                && EqualityComparer<Object>.Default.Equals(m_Item2, objTuple.m_Item2)
                && EqualityComparer<Object>.Default.Equals(m_Item3, objTuple.m_Item3);
        }

        Int32 IComparable.CompareTo(Object obj)
        {
            if (obj == null) return 1;

            Tuple<T1, T2, T3> objTuple = obj as Tuple<T1, T2, T3>;

            if (objTuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, this.GetType().ToString()), nameof(obj));
            }

            int c = 0;

            c = Comparer<Object>.Default.Compare(m_Item1, objTuple.m_Item1);

            if (c != 0) return c;

            c = Comparer<Object>.Default.Compare(m_Item2, objTuple.m_Item2);

            if (c != 0) return c;

            return Comparer<Object>.Default.Compare(m_Item3, objTuple.m_Item3);
        }

        public override int GetHashCode()
        {
            return Tuple.CombineHashCodes(
                EqualityComparer<Object>.Default.GetHashCode(m_Item1),
                EqualityComparer<Object>.Default.GetHashCode(m_Item2),
                EqualityComparer<Object>.Default.GetHashCode(m_Item3));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(')');
            return sb.ToString();
        }
    }
}
#endif
