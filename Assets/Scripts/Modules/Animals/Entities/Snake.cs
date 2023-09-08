namespace Modules.Animals.Entities
{
    public sealed class Snake : MovingAnimal
    {
        public Snake() : base(
            "Snake", 
            new ResourcesPrefabProvider("Snake"), 
            new LinearMovementBehaviour(
                new ConstantSpeedProvider(4), 
                new IntervalBased2DMovementDirectionProvider(
                    new DeltaBoundsSetting<float>(30, 90), 
                    new RandomInBoundsIntervalProvider(new DeltaBoundsSetting<int>(500, 1000)))
                )
            )
        {
        }
    }
}