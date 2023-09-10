using Modules.Animals.Entities;
using Services;

namespace Modules.Animals
{
    /// <summary>
    ///     Snake-only IAnimalFactory implementation
    /// </summary>
    public sealed class SnakeAnimalFactory : AnimalFactory
    {
        public override IAnimal CreateNext() =>
            new Snake(Services);
    }
}