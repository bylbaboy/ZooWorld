namespace Common.Values
{
    public interface IValuesProvider<T>
    {
        T GetNext();
    }
}