using Common;

namespace Services
{
    /// <summary>
    ///     Provides modules with some separated functionality
    /// </summary>
    public interface IService : IDisposable
    {
        void Initialize(IServices services);
    }
}