using System;

namespace Common.Parameters
{
    public interface IValuePicker<T> where T : struct, IComparable<T>
    {
        T Pick(IBounds<T> bounds);
    }
}