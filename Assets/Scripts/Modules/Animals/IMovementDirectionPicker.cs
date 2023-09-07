using UnityEngine;

namespace Modules.Animals
{
    public interface IMovementDirectionPicker
    {
        Vector3 PickNext();
    }
}