using System;

namespace Common.Values
{
    public interface IValuePicker<T> where T : struct, IComparable<T>
    {
        T Pick(IBounds<T> bounds);
    }
}