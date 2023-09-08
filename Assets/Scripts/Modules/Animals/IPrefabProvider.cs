using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Provides with the prefab
    /// </summary>
    public interface IPrefabProvider
    {
        GameObject GetPrefab();
    }
}