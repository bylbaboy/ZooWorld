namespace Common.Parameters
{
    public interface IValuesProvider<T>
    {
        T GetNext();
    }
}