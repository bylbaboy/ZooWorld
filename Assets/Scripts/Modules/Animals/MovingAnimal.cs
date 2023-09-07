using Common;
using UnityEngine;

namespace Modules.Animals
{
    public abstract class MovingAnimal : Animal, IInitializable<Transform>
    {
        private readonly IMovementBehaviour _movementBehaviour;
        
        public override void Dispose()
        {
            _movementBehaviour.Dispose();
        }

        public MovingAnimal(string name, IPrefabProvider prefabProvider, IMovementBehaviour movementBehaviour) : base(name, prefabProvider)
        {
            _movementBehaviour = movementBehaviour;
        }

        public void Initialize(Transform obj)
        {
            _movementBehaviour.Initialize(obj);
        }
    }
}