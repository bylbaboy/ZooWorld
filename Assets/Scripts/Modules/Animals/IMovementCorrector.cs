using Common;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Corrects the movement of the object
    /// </summary>
    public interface IMovementCorrector : IInitializable<Transform>
    {
        Vector3 Correct(Vector3 currentDirection);
    }
}