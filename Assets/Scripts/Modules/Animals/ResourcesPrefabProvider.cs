using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Resources-based IPrefabProvider implementation
    /// </summary>
    public sealed class ResourcesPrefabProvider : IPrefabProvider
    {
        private readonly string _prefabPathFromResources;

        public ResourcesPrefabProvider(string prefabPathFromResources) =>
            _prefabPathFromResources = prefabPathFromResources;

        public GameObject GetPrefab() =>
            Resources.Load<GameObject>(_prefabPathFromResources);
    }
}