﻿using Common;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class ReturnToAreaMovementCorrector : IMovementCorrector
    {
        private const int DIRECTION_DELTA = 10;
        private Transform _objectToMove;
        private Vector3 _areaCenter;
        private float _areaRadius;

        public ReturnToAreaMovementCorrector(Vector3 areaCenter, float areaRadius)
        {
            _areaCenter = areaCenter;
            _areaRadius = areaRadius;
        }

        public void Initialize(Transform obj)
        {
            _objectToMove = obj;
        }

        public Vector3 Correct(Vector3 currentDirection)
        {
            var toCenter = (_areaCenter - _objectToMove.position);
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
    }
}