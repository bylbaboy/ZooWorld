using System;

namespace Common.Values
{
    /// <summary>
    /// IValuesProvider based on the provided bounds
    /// </summary>
    /// <typeparam name="T">Provided value type</typeparam>
    public sealed class BoundedValuesProvider<T> : IValuesProvider<T> where T : struct, IComparable<T>
    {
        private IBounds<T> _bounds;
        private IValuePicker<T> _picker;

        public BoundedValuesProvider(IBounds<T> bounds, IValuePicker<T> picker)
        {
            _bounds = bounds;
            _picker = picker;
        }

        public T GetNext() =>
            _picker.Pick(_bounds);
    }
}