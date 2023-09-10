using Services;

namespace Modules.Animals
{
    /// <summary>
    ///     Basic IAnimalFactory implementation
    /// </summary>
    public abstract class AnimalFactory : IAnimalFactory
    {
        protected IServices Services { get; private set; }

        public void Initialize(IServices services) =>
            Services = services;

        public abstract IAnimal CreateNext();
    }
}