namespace Common.Values
{
    /// <summary>
    ///     Provides some values
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public interface IValuesProvider<T>
    {
        T GetNext();
    }
}