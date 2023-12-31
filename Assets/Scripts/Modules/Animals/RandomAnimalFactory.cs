﻿using Modules.Animals.Entities;
using Tools;

namespace Modules.Animals
{
    /// <summary>
    ///     Random values-based IAnimalFactory implementation
    /// </summary>
    public sealed class RandomAnimalFactory : AnimalFactory
    {
        private readonly WeightBasedRandom<IAnimal> _random;

        public RandomAnimalFactory()
        {
            _random = new WeightBasedRandom<IAnimal>(
                (10, () => new Snake(Services)),
                (30, () => new Frog(Services))
            );
        }

        public override IAnimal CreateNext() =>
            _random.GetNext();
    }
}