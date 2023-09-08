using Common;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Provides with the movement direction for the object
    /// </summary>
    public interface IMovementDirectionProvider : IDisposable
    {
        Vector3 GetDirection();

        void Initialize();
    }
}