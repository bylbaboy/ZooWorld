using Modules.Animals.Entities;

namespace Modules.Animals
{
    public sealed class SnakeAnimalFactory : IAnimalFactory
    {
        public IAnimal CreateNext() =>
            new Snake();
    }
}