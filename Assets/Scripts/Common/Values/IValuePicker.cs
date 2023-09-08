using System;

namespace Common.Values
{
    /// <summary>
    ///     Picks value from the bounds
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public interface IValuePicker<T> where T : struct, IComparable<T>
    {
        T Pick(IBounds<T> bounds);
    }
}