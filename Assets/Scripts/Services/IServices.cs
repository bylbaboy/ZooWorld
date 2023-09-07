using Common;

namespace Services
{
    /// <summary>
    ///     Stores services collection
    /// </summary>
    public interface IServices : IDisposable
    {
        /// <summary>
        ///     Tries to get the service of specified type
        /// </summary>
        /// <typeparam name="T">Type of the service</typeparam>
        /// <returns>Service of the provided type if found, false otherwise</returns>
        T Get<T>() where T : IService;
    }
}