using UnityEngine;

namespace Common.Values
{
    /// <summary>
    ///     Random float IValuePicker implementation
    /// </summary>
    public sealed class RandomFloatPicker : IValuePicker<float>
    {
        public float Pick(IBounds<float> bounds) =>
            bounds.Min + (bounds.Max - bounds.Min * Random.Range(0, 1f));
    }
}