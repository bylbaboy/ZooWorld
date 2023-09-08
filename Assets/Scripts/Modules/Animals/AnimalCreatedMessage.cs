using UnityEngine;

namespace Modules.Animals
{
    public sealed class AnimalCreatedMessage
    {
        public readonly IAnimal Animal;
        public readonly GameObject Object;

        public AnimalCreatedMessage(IAnimal animal, GameObject o)
        {
            Animal = animal;
            Object = o;
        }
    }
}