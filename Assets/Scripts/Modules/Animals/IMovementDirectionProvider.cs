using Common;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    /// Provides with the movement direction for the object
    /// </summary>
    public interface IMovementDirectionProvider : IDisposable
    {
        void Initialize();
        Vector3 GetDirection();
    }
}