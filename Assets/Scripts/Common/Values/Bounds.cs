namespace Common.Values
{
    /// <summary>
    ///     Generic IBounds implementation
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public sealed class Bounds<T> : IBounds<T> where T : struct
    {
        public T Min { get; }
        public T Max { get; }

        public Bounds(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }
}