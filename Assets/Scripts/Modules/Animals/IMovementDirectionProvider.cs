using Common;
using UnityEngine;

namespace Modules.Animals
{
    public interface IMovementDirectionProvider : IDisposable
    {
        Vector3 GetDirection();
    }
}