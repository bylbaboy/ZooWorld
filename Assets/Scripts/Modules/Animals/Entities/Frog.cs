﻿using Common;
using Common.Values;
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
                new ConstantValuesProvider<int>(0),
                new ResourcesPrefabProvider("Frog"),
                new JumpMovementBehaviour(
                    new ConstantSpeedProvider(8),
                    new IntervalBased2DMovementDirectionProvider(
                        new BoundedValuesProvider<float>(new Bounds<float>(45, 180), new RandomFloatPicker()), 
                        new BoundedValuesProvider<int>(new Bounds<int>(1000, 4000), new RandomIntPicker())
                    ),
                    new BoundedValuesProvider<int>(new Bounds<int>(1500, 2500), new RandomIntPicker())
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