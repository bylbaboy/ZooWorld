namespace Common.Values
{
    /// <summary>
    /// Generic IConstantValuesProvider implementation
    /// </summary>
    /// <typeparam name="T">Values type</typeparam>
    public sealed class ConstantValuesProvider<T> : IConstantValuesProvider<T>
    {
        private T _parameter;

        public ConstantValuesProvider(T parameter) =>
            _parameter = parameter;

        public T GetNext() =>
            _parameter;
    }
}