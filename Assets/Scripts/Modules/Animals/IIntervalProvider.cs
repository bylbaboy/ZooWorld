using System;

namespace Modules.Animals
{
    public interface IIntervalProvider<T> where T : struct, IComparable<T>
    {
        T GetNextInterval();
    }
}