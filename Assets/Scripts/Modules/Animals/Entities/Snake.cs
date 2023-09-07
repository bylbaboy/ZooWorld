namespace Modules.Animals.Entities
{
    public sealed class Snake : MovingAnimal
    {
        public Snake() : base(
            "Snake", 
            new ResourcesPrefabProvider("Snake"), 
            new LinearMovementBehaviour(
                null, 
                new ConstantSpeedProvider(4), 
                new IntervalBased2DMovementDirectionProvider(
                    new DeltaBoundsSetting<float>(15, 45), 
                    new RandomInBoundsIntervalProvider(new DeltaBoundsSetting<int>(1, 3)))
                )
            )
        {
        }
        
        public override void Dispose()
        {
        }
    }
}