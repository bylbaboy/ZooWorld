using UnityEngine;

namespace Common.Parameters
{
    public sealed class RandomFloatPicker : IValuePicker<float>
    {
        public float Pick(IBounds<float> bounds) =>
            bounds.Min + (bounds.Max - bounds.Min * Random.Range(0, 1f));
    }
}