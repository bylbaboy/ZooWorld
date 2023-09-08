using Common;
using UnityEngine;

namespace Modules.Animals
{
    public interface IMovementBehaviour : IInitializable<Transform>, IDisposable
    {
        IMovementBehaviour SetCorrector(IMovementCorrector corrector);
    }
}