using Common;
using Common.Values;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Moving extension for the Animal implementation
    /// </summary>
    public abstract class MovingAnimal : Animal, IInitializable<Transform>
    {
        private readonly IMovementBehaviour _movementBehaviour;

        protected MovingAnimal(string name, IConstantValuesProvider<int> predationLevel, IPrefabProvider prefabProvider,
            IMovementBehaviour movementBehaviour) : base(name, predationLevel, prefabProvider) =>
            _movementBehaviour = movementBehaviour;

        public void Initialize(Transform obj) =>
            _movementBehaviour.Initialize(obj);

        public override void Dispose()
        {
            _movementBehaviour.Dispose();
        }
    }
}