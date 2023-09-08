using System;

namespace Common.Values
{
    public interface IBounds<T> where T : struct
    {
        public T Min { get; }
        public T Max{ get; }
    }
}