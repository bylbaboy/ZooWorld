namespace Common
{
    public interface IInitializable<T>
    {
        void Initialize(T obj);
    }
}