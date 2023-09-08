using System;

namespace Tools
{
    /// <summary>
    /// Chooses the entities based on the weight random
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public sealed class WeightBasedRandom<T>
    {
        private readonly Random _random;
        private readonly int _totalWeight = 0;
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