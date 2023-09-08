using Common;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Controls movement of the object
    /// </summary>
    public interface IMovementBehaviour : IInitializable<Transform>, IDisposable
    {
        IMovementBehaviour SetCorrector(IMovementCorrector corrector);
    }
}