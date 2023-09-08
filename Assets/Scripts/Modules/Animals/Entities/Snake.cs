using Common;
using Common.Values;
using UnityEngine;

namespace Modules.Animals.Entities
{
    /// <summary>
    ///     Snake IAnimal implementation
    /// </summary>
    public sealed class Snake : MovingAnimal
    {
        private readonly MovingAnimal _baseAnimal;

        public Snake() : base(
            "Snake",
            new ConstantValuesProvider<int>(Random.Range(3, 5)),
            new ResourcesPrefabProvider("Snake"),
            new LinearMovementBehaviour(
                new ConstantSpeedProvider(4),
                new IntervalBased2DMovementDirectionProvider(
                    new BoundedValuesProvider<float>(new Bounds<float>(30, 90), new RandomFloatPicker()),
                    new BoundedValuesProvider<int>(new Bounds<int>(500, 1000), new RandomIntPicker())
                )
            ).SetCorrector(new ReturnToAreaMovementCorrector(Vector3.zero, Constants.AREA_TO_RETURN))
        )
        {
        }
    }
}