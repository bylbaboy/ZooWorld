
using UnityEngine;

namespace Modules.Animals
{
    public abstract class MovementBehaviour : IMovementBehaviour
    {
        private Transform _objectToMove;
        private readonly ISpeedProvider _speedProvider;
        private readonly IMovementDirectionProvider _directionProvider;
        private IMovementCorrector _movementCorrector;

        protected Transform ObjectToMove => _objectToMove;
        protected ISpeedProvider SpeedProvider => _speedProvider;
        protected IMovementDirectionProvider DirectionProvider => _directionProvider;
        protected IMovementCorrector MovementCorrector => _movementCorrector;

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
            _movementCorrector.Initialize(objectToMove);

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

        public IMovementBehaviour SetCorrector(IMovementCorrector corrector)
        {
            _movementCorrector = corrector;
            return this;
        }

        protected virtual void OnDispose()
        {
            
        }
    }
}