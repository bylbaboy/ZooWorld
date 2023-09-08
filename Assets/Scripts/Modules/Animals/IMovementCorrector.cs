using Common;
using UnityEngine;

namespace Modules.Animals
{
    public interface IMovementCorrector : IInitializable<Transform>
    {
        Vector3 Correct(Vector3 currentDirection);
    }
}