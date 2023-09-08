using Modules.Animals.Entities;

namespace Modules.Animals
{
    public sealed class SnakeAnimalPicker : IAnimalPicker
    {
        public IAnimal GetNext() =>
            new Snake();
    }
}