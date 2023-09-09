using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Returning to the specified area IMovementCorrector implementation
    /// </summary>
    public sealed class ReturnToAreaMovementDirectionCorrector : IMovementDirectionCorrector
    {
        private const int DIRECTION_DELTA = 10;
        private Transform _objectToMove;
        private readonly Vector3 _areaCenter;
        private readonly float _areaRadius;

        public ReturnToAreaMovementDirectionCorrector(Vector3 areaCenter, float areaRadius)
        {
            _areaCenter = areaCenter;
            _areaRadius = areaRadius;
        }

        public Vector3 Correct(Vector3 currentDirection)
        {
            var toCenter = _areaCenter - _objectToMove.position;
            toCenter.y = 0;
            if (toCenter.magnitude < _areaRadius)
            {
                return currentDirection;
            }
            toCenter.Normalize();

            var currentDirectionFlat = currentDirection;
            currentDirectionFlat.y = 0;
            currentDirectionFlat.Normalize();

            var angleBetween = Vector2.SignedAngle(toCenter, currentDirectionFlat);

            if (Mathf.Abs(angleBetween) <= DIRECTION_DELTA)
            {
                return currentDirection;
            }

            var rotation = Random.Range(-DIRECTION_DELTA, (float) DIRECTION_DELTA);
            var correctedDirection = Quaternion.Euler(0, rotation, 0) * toCenter;
            correctedDirection.y = currentDirection.y;
            correctedDirection.Normalize();
            return correctedDirection;
        }

        public void Initialize(Transform obj)
        {
            _objectToMove = obj;
        }
    }
}