namespace Modules.Animals
{
    /// <summary>
    ///     Notifies when an animal dies
    /// </summary>
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