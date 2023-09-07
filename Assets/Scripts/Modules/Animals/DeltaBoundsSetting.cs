using System;

namespace Modules.Animals
{
    public sealed class DeltaBoundsSetting<T> : IDeltaBoundsSetting<T> where T : struct, IComparable<T>
    {
        private T _minDelta;
        private T _maxDelta;

        public T MinDelta => _minDelta;
        public T MaxDelta => _maxDelta;

        public DeltaBoundsSetting(T minDelta, T maxDelta)
        {
            _minDelta = minDelta;
            _maxDelta = maxDelta;

            if (_minDelta.CompareTo(_maxDelta) > 0)
            {
                throw new Exception("Incorrect delta setting");
            }
        }
    }
}