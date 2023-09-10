using Common.Values;
using Services;
using UnityEngine;

namespace Modules.Animals.Entities
{
    /// <summary>
    ///     Snake IAnimal implementation
    /// </summary>
    public sealed class Snake : MovingAnimal
    {
        private readonly MovingAnimal _baseAnimal;

        public Snake(IServices services) : base(
            "Snake",
            new ConstantValuesProvider<int>(Random.Range(3, 5)),
            new ResourcesPrefabProvider("Snake"),
            new LinearMovementBehaviour(
                new ConstantSpeedProvider(4),
                new IntervalBased2DMovementDirectionProvider(
                    new BoundedValuesProvider<float>(new Bounds<float>(30, 90), new RandomFloatPicker()),
                    new BoundedValuesProvider<int>(new Bounds<int>(500, 1000), new RandomIntPicker())
                ).SetCorrector(new ReturnToCameraViewDirectionCorrector(services.Get<ICameraService>()))
            )
        )
        {
        }
    }
}