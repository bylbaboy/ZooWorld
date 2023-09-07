using System.Collections.Generic;
using System.Linq;

namespace Modules.Animals
{
    public abstract class AnimalSet : IAnimalSet
    {
        private IAnimal[] _animals;

        public AnimalSet(params IAnimal[] animals) =>
            _animals = animals;

        public List<IAnimal> GetAnimals() =>
            _animals.ToList();
    }
}