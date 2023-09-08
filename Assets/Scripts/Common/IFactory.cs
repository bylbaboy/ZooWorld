namespace Common
{
    /// <summary>
    ///     Creates generic objects
    /// </summary>
    /// <typeparam name="T">Created object type</typeparam>
    public interface IFactory<T>
    {
        T CreateNext();
    }
}