namespace Common
{
    /// <summary>
    /// Shows that object should be initialized
    /// </summary>
    /// <typeparam name="T">Type of the object that should be provided for the initialization</typeparam>
    public interface IInitializable<T>
    {
        void Initialize(T obj);
    }
}