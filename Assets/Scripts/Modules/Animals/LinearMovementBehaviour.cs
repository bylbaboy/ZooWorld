using System;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    /// Linear MovementBehaviour implementation
    /// </summary>
    public sealed class LinearMovementBehaviour : MovementBehaviour
    {
        private IDisposable _updating;
        
        public LinearMovementBehaviour(ISpeedProvider speedProvider, IMovementDirectionProvider directionProvider) : base(speedProvider, directionProvider)
        {
        }

        protected override void OnInitialize()
        {
            _updating = UniTaskAsyncEnumerable.EveryUpdate().Subscribe(_ => Move());
        }

        protected override void OnDispose()
        {
            _updating?.Dispose();
        }

        private void Move()
        {
            var direction = DirectionProvider.GetDirection().normalized;
            var correctedDirection = MovementCorrector.Correct(direction);
            var translation = correctedDirection * SpeedProvider.GetSpeed() * Time.deltaTime;
            ObjectToMove.Translate(translation);
        }
    }
}