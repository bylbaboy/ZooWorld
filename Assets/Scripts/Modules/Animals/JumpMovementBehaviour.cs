using System;
using Common.Parameters;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class JumpMovementBehaviour : MovementBehaviour
    {
        private readonly IValuesProvider<int> _jumpDelaysProvider;
        private IDisposable _jumping;

        public JumpMovementBehaviour(
            ISpeedProvider speedProvider, 
            IMovementDirectionProvider directionProvider, 
            IValuesProvider<int> jumpDelaysProvider) : base(speedProvider, directionProvider)
        {
            _jumpDelaysProvider = jumpDelaysProvider;
        }

        protected override void OnInitialize()
        {
            Jump();
        }

        private void Jump()
        {
            var rb = ObjectToMove.GetComponent<Rigidbody>();
            var direction = DirectionProvider.GetDirection();
            direction.Normalize();
            direction.y = 1;
            direction.Normalize();

            rb.AddForce(direction * SpeedProvider.GetSpeed(), ForceMode.Impulse);

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
    }
}