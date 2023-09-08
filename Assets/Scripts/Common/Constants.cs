using Common.Values;
using UnityEngine;

namespace Common
{
    /// <summary>
    ///     Common constants of the project
    /// </summary>
    public static class Constants
    {
        public const int AREA_TO_RETURN = 15;
        public static readonly int ANIMALS_LAYER = LayerMask.NameToLayer("Animals");
        public static readonly IBounds<Vector2> SPAWN_AREA = new Bounds<Vector2>(Vector2.one * -15, Vector2.one * 15);
    }
}