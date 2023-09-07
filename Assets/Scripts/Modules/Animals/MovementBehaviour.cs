
using UnityEngine;

namespace Modules.Animals
{
    public abstract class MovementBehaviour : IMovementBehaviour
    {
        private Transform _objectToMove;
        private readonly ISpeedProvider _speedProvider;
        private readonly IMovementDirectionProvider _directionProvider;

        protected Transform ObjectToMove => _objectToMove;
        protected ISpeedProvider SpeedProvider => _speedProvider;
        protected IMovementDirectionProvider DirectionProvider => _directionProvider;

        protected MovementBehaviour(ISpeedProvider speedProvider, IMovementDirectionProvider directionProvider)
        {
            _speedProvider = speedProvider;
            _directionProvider = directionProvider;
        }

        public void Initialize(Transform objectToMove)
        {
            _objectToMove = objectToMove;
            _speedProvider.Initialize();
            _directionProvider.Initialize();

            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }

        public void Dispose()
        {
            _speedProvider.Dispose();
            _directionProvider.Dispose();
            
            OnDispose();
        }

        protected virtual void OnDispose()
        {
            
        }
    }
}