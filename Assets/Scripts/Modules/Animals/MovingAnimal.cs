namespace Modules.Animals
{
    public abstract class MovingAnimal : Animal
    {
        private readonly IMovementBehaviour _movementBehaviour;
        
        public override void Dispose()
        {
            _movementBehaviour.Dispose();
        }

        public MovingAnimal(string name, IPrefabProvider prefabProvider, IMovementBehaviour movementBehaviour) : base(name, prefabProvider)
        {
            _movementBehaviour = movementBehaviour;
        }
    }
}