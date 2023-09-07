
using UnityEngine;

namespace Modules.Animals
{
    public abstract class MovementBehaviour : IMovementBehaviour
    {
        private readonly Transform _objectToMove;
        private ISpeedProvider _speedProvider;

        protected Transform ObjectToMove => _objectToMove;
        protected ISpeedProvider SpeedProvider => _speedProvider;

        protected MovementBehaviour(Transform objectToMove, ISpeedProvider speedProvider)
        {
            _objectToMove = objectToMove;
            _speedProvider = speedProvider;
        }

        public abstract void Dispose();
    }
}