namespace Modules.Animals
{
    public sealed class AnimalDiedMessage
    {
        public readonly IAnimal Victim;
        public readonly IAnimal Killer;

        public AnimalDiedMessage(IAnimal victim, IAnimal killer)
        {
            Victim = victim;
            Killer = killer;
        }
    }
}