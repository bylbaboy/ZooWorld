using Services;
using UnityEngine;

namespace Modules.Animals
{
    /// <summary>
    ///     Returning to the specified area IMovementCorrector implementation
    /// </summary>
    public sealed class ReturnToCameraViewDirectionCorrector : IMovementDirectionCorrector
    {
        private const int DIRECTION_DELTA = 10;
        private readonly ICameraService _camera;
        private Transform _objectToMove;

        public ReturnToCameraViewDirectionCorrector(ICameraService camera) =>
            _camera = camera;

        public Vector3 Correct(Vector3 currentDirection)
        {
            if (IsVisibleByTheCamera())
            {
                return currentDirection;
            }

            var camera = _camera.GetCamera();
            var ray = new Ray(camera.transform.position, camera.transform.forward);
            var groundY = 0;
            var viewPoint = ray.GetPoint((groundY - ray.origin.y) / ray.direction.y);

            var toCenter = viewPoint - _objectToMove.position;
            toCenter.y = 0;
            toCenter.Normalize();

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

        private bool IsVisibleByTheCamera()
        {
            var viewportPoint = _camera.GetCamera().WorldToViewportPoint(_objectToMove.position);
            return viewportPoint.x is >= 0 and <= 1 && viewportPoint.y is >= 0 and <= 1 && viewportPoint.z > 0;
        }
    }
}