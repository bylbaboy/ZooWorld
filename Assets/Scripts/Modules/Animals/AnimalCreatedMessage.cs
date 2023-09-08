using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    /// Notifies when an animal is created
    /// </summary>
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