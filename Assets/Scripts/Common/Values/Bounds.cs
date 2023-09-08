using System;

namespace Common.Values
{
    /// <summary>
    /// Generic IBounds implementation
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public sealed class Bounds<T> : IBounds<T> where T : struct
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