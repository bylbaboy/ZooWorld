using System.Collections.Generic;

namespace Modules.Animals
{
    public interface IAnimalSet
    {
        List<IAnimal> GetAnimals();
    }
}