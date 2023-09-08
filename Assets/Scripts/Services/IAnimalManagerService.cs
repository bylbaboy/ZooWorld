using Modules.Animals;
using UnityEngine;

namespace Services
{
    /// <summary>
    /// Manges animals on the scene
    /// </summary>
    public interface IAnimalManagerService : IService
    {
        bool TryGetAnimal(GameObject obj, out IAnimal animal);
        bool TryGetObject(IAnimal animal, out GameObject obj);
    }
}