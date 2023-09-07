using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class LinearMovementBehaviour : MovementBehaviour
    {
        public LinearMovementBehaviour(Transform objectToMove, ISpeedProvider speedProvider, IMovementDirectionProvider directionProvider) : base(objectToMove, speedProvider, directionProvider)
        {
            UniTaskAsyncEnumerable.EveryUpdate().Subscribe(_ => Move());
        }

        private void Move()
        {
            var translation = DirectionProvider.GetDirection().normalized * SpeedProvider.GetSpeed() * Time.deltaTime;
            ObjectToMove.Translate(translation);
        }
    }
}