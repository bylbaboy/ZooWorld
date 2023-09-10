using Services;

namespace Modules.Animals
{
    /// <summary>
    /// Basic IAnimalFactory implementation
    /// </summary>
    public abstract class AnimalFactory : IAnimalFactory
    {
        private IServices _services;
        protected IServices Services => _services;
        
        public abstract IAnimal CreateNext();

        public void Initialize(IServices services) =>
            _services = services;
    }
}