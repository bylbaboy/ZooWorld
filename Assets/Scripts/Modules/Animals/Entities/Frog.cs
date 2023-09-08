using Common;
using Common.Values;
using UnityEngine;

namespace Modules.Animals.Entities
{
    /// <summary>
    /// Frog IAnimal implementation
    /// </summary>
    public sealed class Frog : MovingAnimal
    {
        private readonly MovingAnimal _baseAnimal;
        
        public Frog() : base(
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
            ).SetCorrector(new ReturnToAreaMovementCorrector(Vector3.zero, Constants.AREA_TO_RETURN))
            )
        {
        }
    }
}