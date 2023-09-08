using Common;
using UnityEngine;

namespace Modules.Animals
{
    public interface IAnimal : IDisposable
    {
        string GetName();
        GameObject GetPrefab();

        int GetPredationLevel();
    }
}