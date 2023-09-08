using Modules.Animals.Entities;
using Tools;

namespace Modules.Animals
{
    public sealed class RandomAnimalPicker : IAnimalPicker
    {
        private readonly WeightBasedRandom<IAnimal> _random;
        
        public RandomAnimalPicker()
        {
            _random = new WeightBasedRandom<IAnimal>(
                (10, () => new Snake()),
                (30, () => new Frog())
            );
        }
        
        public IAnimal GetNext()
        {
            return _random.GetNext();
        }
    }
}