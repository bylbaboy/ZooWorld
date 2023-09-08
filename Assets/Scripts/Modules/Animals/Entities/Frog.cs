namespace Modules.Animals.Entities
{
    public sealed class Frog : MovingAnimal
    {
        public Frog() : base(
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
            )
        {
        }
    }
}