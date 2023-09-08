using Common;
using Common.Values;
using UnityEngine;

namespace Modules.Animals.Entities
{
    public sealed class Snake : IAnimal, IInitializable<Transform>
    {
        private readonly MovingAnimal _baseAnimal;

        public Snake()
        {
            _baseAnimal = new MovingAnimal(
                "Snake",
                new BoundedValuesProvider<int>(new Bounds<int>(3, 5), new RandomIntPicker()),
                new ResourcesPrefabProvider("Snake"),
                new LinearMovementBehaviour(
                    new ConstantSpeedProvider(4),
                    new IntervalBased2DMovementDirectionProvider(
                        new BoundedValuesProvider<float>(new Bounds<float>(30, 90), new RandomFloatPicker()),
                        new BoundedValuesProvider<int>(new Bounds<int>(500, 1000), new RandomIntPicker())
                    )
                )
            );
        }

        public void Dispose() =>
            _baseAnimal.Dispose();

        public string GetName() =>
            _baseAnimal.GetName();

        public GameObject GetPrefab() =>
            _baseAnimal.GetPrefab();

        public int GetPredationLevel() =>
            _baseAnimal.GetPredationLevel();

        public void Initialize(Transform obj) =>
            _baseAnimal.Initialize(obj);
    }
}