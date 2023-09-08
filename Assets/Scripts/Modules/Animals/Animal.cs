using Common.Values;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Base IAnimal implementation
    /// </summary>
    public abstract class Animal : IAnimal
    {
        private readonly string _name;
        private readonly IValuesProvider<int> _predationLevel;
        private readonly IPrefabProvider _prefabProvider;

        protected Animal(string name, IConstantValuesProvider<int> predationLevel, IPrefabProvider prefabProvider)
        {
            _name = name;
            _predationLevel = predationLevel;
            _prefabProvider = prefabProvider;
        }

        public string GetName() =>
            _name;

        public int GetPredationLevel() =>
            _predationLevel.GetNext();

        public GameObject GetPrefab() =>
            _prefabProvider.GetPrefab();

        public virtual void Dispose()
        {
        }
    }
}