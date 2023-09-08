using System.Collections.Generic;

namespace Modules.Animals
{
    public interface IAnimalPicker
    {
        IAnimal GetNext();
    }
}