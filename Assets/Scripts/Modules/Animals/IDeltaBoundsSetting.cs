using System;

namespace Modules.Animals
{
    public interface IDeltaBoundsSetting<T> where T : struct, IComparable<T>
    {
        public T MinDelta { get; }
        public T MaxDelta { get; }
    }
}