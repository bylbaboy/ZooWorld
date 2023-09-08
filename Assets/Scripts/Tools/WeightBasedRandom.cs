using System;

namespace Tools
{
    public sealed class WeightBasedRandom<T>
    {
        private readonly Random _random;
        private int _totalWeight = 0;
        private (int weight, Func<T> func)[] _entities;
        
        public WeightBasedRandom(params (int weight, Func<T> func)[] entities)
        {
            _random = new Random();
            _entities = entities;
            foreach (var entity in entities)
            {
                if (entity.weight <= 0)
                {
                    throw new InvalidOperationException("Incorrect entity weight");
                }
                
                _totalWeight += entity.weight;
            }
        }
        
        public T GetNext()
        {
            var randomWeight = _random.Next(0, _totalWeight);
            
            var currentWeight = 0;
            foreach (var entity in _entities)
            {
                currentWeight += entity.weight;
                if (randomWeight < currentWeight)
                {
                    return entity.func();
                }
            }
            
            throw new InvalidOperationException("Weights are not properly defined");
        }
    }
}