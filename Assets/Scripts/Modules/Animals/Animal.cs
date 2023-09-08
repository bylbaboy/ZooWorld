using Common.Values;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class Animal : IAnimal
    {
        private readonly string _name;
        private readonly IValuesProvider<int> _predationLevel;
        private readonly IPrefabProvider _prefabProvider;

        public Animal(string name, IValuesProvider<int> predationLevel, IPrefabProvider prefabProvider)
        {
            _name = name;
            _predationLevel = predationLevel;
            _prefabProvider = prefabProvider;
        }

        public string GetName() =>
            _name;

        public GameObject GetPrefab() =>
            _prefabProvider.GetPrefab();

        public int GetPredationLevel() =>
            _predationLevel.GetNext();

        public void Dispose()
        {
        }
    }
}