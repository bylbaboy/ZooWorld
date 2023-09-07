using UnityEngine;

namespace Modules.Animals
{
    public sealed class ResourcesPrefabProvider : IPrefabProvider
    {
        private string _prefabPathFromResources;

        public ResourcesPrefabProvider(string prefabPathFromResources) =>
            _prefabPathFromResources = prefabPathFromResources;

        public GameObject GetPrefab() =>
            Resources.Load<GameObject>(_prefabPathFromResources);
    }
}