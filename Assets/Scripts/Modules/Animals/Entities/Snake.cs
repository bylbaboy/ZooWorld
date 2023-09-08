﻿using Common;
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
                new ResourcesPrefabProvider("Snake"),
                new LinearMovementBehaviour(
                    new ConstantSpeedProvider(4),
                    new IntervalBased2DMovementDirectionProvider(
                        new DeltaBoundsSetting<float>(30, 90),
                        new RandomInBoundsIntervalProvider(new DeltaBoundsSetting<int>(500, 1000))
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

        public void Initialize(Transform obj) =>
            _baseAnimal.Initialize(obj);
    }
}