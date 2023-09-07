using UnityEngine;
using Random = UnityEngine.Random;

namespace Modules.Animals
{
    public sealed class RandomInBoundsIntervalProvider : IIntervalProvider<int>
    {
        private IDeltaBoundsSetting<int> _changeBounds;

        public RandomInBoundsIntervalProvider(IDeltaBoundsSetting<int> changeBounds)
        {
            _changeBounds = changeBounds;
        }

        public int GetNextInterval() =>
            _changeBounds.MinDelta + Mathf.RoundToInt((_changeBounds.MaxDelta - _changeBounds.MinDelta) * Random.Range(0, 1f));
    }
}