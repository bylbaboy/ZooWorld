namespace Services
{
    /// <summary>
    ///     Basic IService implementation
    /// </summary>
    public class Service : IService
    {
        public virtual void Dispose()
        {
        }

        public virtual void Initialize(IServices services)
        {
        }
    }
}