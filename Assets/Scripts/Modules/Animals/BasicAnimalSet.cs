using Modules.Animals.Entities;

namespace Modules.Animals
{
    public sealed class BasicAnimalSet : AnimalSet
    {
        private IAnimalSet _baseSet;

        public BasicAnimalSet() : base(new Snake()) {}
    }
}