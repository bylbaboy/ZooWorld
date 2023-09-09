using Common;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Corrects the movement of the object
    /// </summary>
    public interface IMovementDirectionCorrector : IInitializable<Transform>
    {
        Vector3 Correct(Vector3 currentDirection);
    }
}