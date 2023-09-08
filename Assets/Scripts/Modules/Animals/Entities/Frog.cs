using Common;
using UnityEngine;

namespace Modules.Animals.Entities
{
    public sealed class Frog : IAnimal, IInitializable<Transform>
    {
        private readonly MovingAnimal _baseAnimal;
        
        public Frog()
        {
            _baseAnimal = new MovingAnimal(
                "Frog",
                new ResourcesPrefabProvider("Frog"),
                new JumpMovementBehaviour(
                    new ConstantSpeedProvider(6),
                    new IntervalBased2DMovementDirectionProvider(
                        new DeltaBoundsSetting<float>(45, 180),
                        new RandomInBoundsIntervalProvider(new DeltaBoundsSetting<int>(1000, 4000))
                    ),
                    new RandomInBoundsIntervalProvider(new DeltaBoundsSetting<int>(1000, 2000))
                )
            );
        }

        public void Dispose() =>
            _baseAnimal.Dispose();

        public string GetName() =>
            _baseAnimal.GetName();

        public GameObject GetPrefab() =>
            _baseAnimal.GetPrefab();

        public void Initialize(Transform obj) =>
            _baseAnimal.Initialize(obj);
    }
}