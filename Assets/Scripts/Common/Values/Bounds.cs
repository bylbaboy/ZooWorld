using System;

namespace Common.Values
{
    public sealed class Bounds<T> : IBounds<T> where T : struct, IComparable<T>
    {
        private T _min;
        private T _max;

        public Bounds(T min, T max)
        {
            _min = min;
            _max = max;
        }

        public T Min => _min;
        public T Max => _max;
    }
}