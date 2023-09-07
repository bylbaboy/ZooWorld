using Cysharp.Threading.Tasks.Linq;

namespace Modules.Animals
{
    public sealed class LinearMovementBehaviour : IMovementBehaviour
    {
        private float _speed;
        private float _directionChangesCountPerMinute;
        private IMovementDirectionPicker _directionPicker;

        public LinearMovementBehaviour(float speed, float directionChangesCountPerMinute, IMovementDirectionPicker directionPicker)
        {
            _speed = speed;
            _directionChangesCountPerMinute = directionChangesCountPerMinute;
            _directionPicker = directionPicker;
            
            UniTaskAsyncEnumerable.EveryUpdate().Subscribe(_ => UnityEngine.PlayerLoop.Update());
        }

        public void Dispose()
        {
            
        }
    }
}