namespace Common.Values
{
    /// <summary>
    ///     Object to store the generic bounds
    /// </summary>
    /// <typeparam name="T">Bounds value type</typeparam>
    public interface IBounds<T> where T : struct
    {
        public T Min { get; }
        public T Max { get; }
    }
}