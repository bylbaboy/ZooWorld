using Common;
using Common.Values;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class MovingAnimal : IAnimal, IInitializable<Transform>
    {
        private readonly IAnimal _baseAnimal;
        private readonly IMovementBehaviour _movementBehaviour;
        
        public void Dispose()
        {
            _movementBehaviour.Dispose();
            _baseAnimal.Dispose();
        }
        
        public MovingAnimal(string name, IConstantValuesProvider<int> predationLevel, IPrefabProvider prefabProvider, IMovementBehaviour movementBehaviour)
        {
            _baseAnimal = new Animal(name, predationLevel, prefabProvider);
            _movementBehaviour = movementBehaviour;
        }

        public void Initialize(Transform obj) =>
            _movementBehaviour.Initialize(obj);

        public string GetName() =>
            _baseAnimal.GetName();

        public GameObject GetPrefab() =>
            _baseAnimal.GetPrefab();

        public int GetPredationLevel() =>
            _baseAnimal.GetPredationLevel();
    }
}