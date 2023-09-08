using UnityEngine;

namespace Common.Values
{
    /// <summary>
    ///     Random int IValuePicker implementation
    /// </summary>
    public sealed class RandomIntPicker : IValuePicker<int>
    {
        public int Pick(IBounds<int> bounds) =>
            bounds.Min + Mathf.RoundToInt((bounds.Max - bounds.Min) * Random.Range(0, 1f));
    }
}