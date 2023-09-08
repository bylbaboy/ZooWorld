using Modules.Animals;
using UnityEngine;

namespace Services
{
    public interface IAnimalManagerService : IService
    {
        bool TryGetAnimal(GameObject obj, out IAnimal animal);
        bool TryGetObject(IAnimal animal, out GameObject obj);
    }
}