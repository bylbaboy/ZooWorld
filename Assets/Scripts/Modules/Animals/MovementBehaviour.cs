
using UnityEngine;

namespace Modules.Animals
{
    public abstract class MovementBehaviour : IMovementBehaviour
    {
        private readonly Transform _objectToMove;
        private readonly ISpeedProvider _speedProvider;
        private readonly IMovementDirectionProvider _directionProvider;

        protected Transform ObjectToMove => _objectToMove;
        protected ISpeedProvider SpeedProvider => _speedProvider;
        protected IMovementDirectionProvider DirectionProvider => _directionProvider;

        protected MovementBehaviour(Transform objectToMove, ISpeedProvider speedProvider, IMovementDirectionProvider directionProvider)
        {
            _objectToMove = objectToMove;
            _speedProvider = speedProvider;
            _directionProvider = directionProvider;
        }

        public void Dispose()
        {
            _speedProvider.Dispose();
            _directionProvider.Dispose();
            
            OnDispose();
        }

        protected void OnDispose()
        {
            
        }
    }
}