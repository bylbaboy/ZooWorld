using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Basic IMovementBehaviour implementation
    /// </summary>
    public abstract class MovementBehaviour : IMovementBehaviour
    {
        protected Transform ObjectToMove { get; private set; }
        protected ISpeedProvider SpeedProvider { get; }
        protected IMovementDirectionProvider DirectionProvider { get; }

        protected MovementBehaviour(ISpeedProvider speedProvider, IMovementDirectionProvider directionProvider)
        {
            SpeedProvider = speedProvider;
            DirectionProvider = directionProvider;
        }

        public void Dispose()
        {
            SpeedProvider.Dispose();
            DirectionProvider.Dispose();

            OnDispose();
        }

        public void Initialize(Transform objectToMove)
        {
            ObjectToMove = objectToMove;
            SpeedProvider.Initialize();
            DirectionProvider.Initialize(objectToMove);

            OnInitialize();
        }

        protected virtual void OnDispose()
        {
        }

        protected virtual void OnInitialize()
        {
        }
    }
}