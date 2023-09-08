using System;

namespace Common.Parameters
{
    public interface IBounds<T> where T : struct, IComparable<T>
    {
        public T Min { get; }
        public T Max{ get; }
    }
}