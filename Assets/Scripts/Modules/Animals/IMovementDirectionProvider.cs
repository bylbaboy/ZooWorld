using Common;
using UnityEngine;

namespace Modules.Animals
{
    public interface IMovementDirectionProvider : IDisposable
    {
        void Initialize();
        Vector3 GetDirection();
    }
}