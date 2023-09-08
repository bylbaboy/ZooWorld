using Modules.Animals.Entities;
using Tools;

namespace Modules.Animals
{
    public sealed class RandomAnimalFactory : IAnimalFactory
    {
        private readonly WeightBasedRandom<IAnimal> _random;

        public RandomAnimalFactory()
        {
            _random = new WeightBasedRandom<IAnimal>(
                (10, () => new Snake()),
                (30, () => new Frog())
            );
        }

        public IAnimal CreateNext() =>
            _random.GetNext();
    }
}