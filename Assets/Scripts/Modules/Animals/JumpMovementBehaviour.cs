using System;
using Common.Values;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Jump MovementBehaviour implementation
    /// </summary>
    public sealed class JumpMovementBehaviour : MovementBehaviour
    {
        private readonly IValuesProvider<int> _jumpDelaysProvider;
        private IDisposable _jumping;

        public JumpMovementBehaviour(
            ISpeedProvider speedProvider,
            IMovementDirectionProvider directionProvider,
            IValuesProvider<int> jumpDelaysProvider) : base(speedProvider, directionProvider) =>
            _jumpDelaysProvider = jumpDelaysProvider;

        private void Jump()
        {
            var rb = ObjectToMove.GetComponent<Rigidbody>();
            var direction = DirectionProvider.GetDirection();
            direction.Normalize();
            direction.y = 2;
            direction.Normalize();

            var correctedDirection = MovementCorrector.Correct(direction);

            rb.AddForce(correctedDirection * SpeedProvider.GetSpeed(), ForceMode.Impulse);

            WaitForJump();
        }

        private void WaitForJump()
        {
            _jumping = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, 0, 0, _jumpDelaysProvider.GetNext()))
                .Subscribe(_ => Jump());
        }

        protected override void OnDispose()
        {
            _jumping?.Dispose();
        }

        protected override void OnInitialize()
        {
            Jump();
        }
    }
}