using System;
using Random = UnityEngine.Random;

namespace Modules.Animals
{
    public sealed class RandomInBoundsIntervalProvider : IIntervalProvider
    {
        private IDeltaBoundsSetting _changeBounds;

        public RandomInBoundsIntervalProvider(IDeltaBoundsSetting changeBounds)
        {
            _changeBounds = changeBounds;
        }

        public int GetNextInterval() =>
            _changeBounds.MinDelta + (_changeBounds.MaxDelta - _changeBounds.MinDelta) * Random.Range(0, 1f);
    }
}