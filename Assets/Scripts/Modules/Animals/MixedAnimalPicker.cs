using Modules.Animals.Entities;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class MixedAnimalPicker : IAnimalPicker
    {
        private readonly System.Random _random;
        
        public MixedAnimalPicker()
        {
            _random = new System.Random(Random.Range(0, 10000));
        }
        
        public IAnimal GetNext()
        {
            return _random.Next(0, 4) switch
            {
                0 => new Snake(),
                _ => new Frog()
            };
        }
    }
}