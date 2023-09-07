using Common;

namespace Services
{
    /// <summary>
    ///     Basic IServices implementation
    /// </summary>
    public class Services : IServices
    {
        private readonly TypeHashList<IService> _services;

        public Services(TypeHashList<IService> services)
        {
            _services = services;

            foreach (var service in _services)
            {
                service.Initialize(this);
            }
        }

        public void Dispose()
        {
            foreach (var service in _services)
            {
                service.Dispose();
            }
        }

        public T Get<T>() where T : IService =>
            _services.Get<T>();
    }
}