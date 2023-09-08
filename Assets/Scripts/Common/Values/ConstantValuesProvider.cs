namespace Common.Values
{
    public sealed class ConstantValuesProvider<T> : IValuesProvider<T>
    {
        private T _parameter;

        public ConstantValuesProvider(T parameter) =>
            _parameter = parameter;

        public T GetNext() =>
            _parameter;
    }
}