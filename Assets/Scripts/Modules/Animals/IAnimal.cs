using Common;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    /// Shows that the object is an animal
    /// </summary>
    public interface IAnimal : IDisposable
    {
        string GetName();
        GameObject GetPrefab();

        int GetPredationLevel();
    }
}