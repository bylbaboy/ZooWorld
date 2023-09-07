using UnityEngine;

namespace Modules.Animals
{
    public abstract class Animal : IAnimal
    {
        private readonly string _name;
        private readonly IPrefabProvider _prefabProvider;

        protected Animal(string name, IPrefabProvider prefabProvider)
        {
            _name = name;
            _prefabProvider = prefabProvider;
        }

        public string GetName() =>
            _name;

        public GameObject GetPrefab() =>
            _prefabProvider.GetPrefab();

        public abstract void Dispose();
    }
}