using Modules.Animals.Entities;

namespace Modules.Animals
{
    /// <summary>
    ///     Snake-only IAnimalFactory implementation
    /// </summary>
    public sealed class SnakeAnimalFactory : IAnimalFactory
    {
        public IAnimal CreateNext() =>
            new Snake();
    }
}