using UnityEngine;

namespace Modules.Animals
{
    public interface IMovementDirectionProvider
    {
        Vector3 GetDirection();
    }
}