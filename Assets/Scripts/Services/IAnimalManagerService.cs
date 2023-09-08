using Modules.Animals;
using UnityEngine;

namespace Services
{
    public interface IAnimalManagerService : IService
    {
        IAnimal GetAnimal(GameObject obj);
    }
}