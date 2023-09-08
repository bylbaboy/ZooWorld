namespace Modules.Animals
{
    public sealed class AnimalDiedMessage
    {
        public readonly IAnimal Animal;

        public AnimalDiedMessage(IAnimal animal) =>
            Animal = animal;
    }
}