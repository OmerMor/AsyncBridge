namespace System
{
    internal static class ArrayEx
    {
        public const int MaxArrayLength = 0X7FEFFFFF;

        private static class EmptyArray<T>
        {
            internal static readonly T[] Value = new T[0];
        }

        public static T[] Empty<T>()
        {
            return EmptyArray<T>.Value;
        }
    }
}
