using UnityEngine;

namespace Modules.Animals
{
    public sealed class Animal : IAnimal
    {
        private readonly string _name;
        private readonly IPrefabProvider _prefabProvider;

        public Animal(string name, IPrefabProvider prefabProvider)
        {
            _name = name;
            _prefabProvider = prefabProvider;
        }

        public string GetName() =>
            _name;

        public GameObject GetPrefab() =>
            _prefabProvider.GetPrefab();

        public void Dispose()
        {
        }
    }
}