using Common;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Provides with the movement direction for the object
    /// </summary>
    public interface IMovementDirectionProvider : IInitializable<Transform>, IDisposable
    {
        Vector3 GetDirection();

        IMovementDirectionProvider SetCorrector(IMovementDirectionCorrector directionCorrector);
    }
}