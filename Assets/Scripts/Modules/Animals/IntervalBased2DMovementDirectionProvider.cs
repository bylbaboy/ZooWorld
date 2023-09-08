using System;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Modules.Animals
{
    public sealed class IntervalBased2DMovementDirectionProvider : IMovementDirectionProvider
    {
        private IDeltaBoundsSetting<float> _directionChangeDeltaInDegrees;
        private IIntervalProvider<int> _directionChangeTimeInterval;
        private Vector3 _currentDirection;
        private IDisposable _waitingForDirectionChange;
        private System.Random _random;

        public void Initialize()
        {
            _random = new System.Random(Random.Range(0, 1000));
            _currentDirection = Quaternion.Euler(0, _random.Next(0, 360), 0) * Vector3.forward;
            
            WaitForDirectionChange();
        }

        public Vector3 GetDirection() =>
            _currentDirection;

        public IntervalBased2DMovementDirectionProvider(IDeltaBoundsSetting<float> directionChangeDeltaInDegrees, IIntervalProvider<int> directionChangeTimeInterval)
        {
            _directionChangeDeltaInDegrees = directionChangeDeltaInDegrees;
            _directionChangeTimeInterval = directionChangeTimeInterval;
        }

        private void WaitForDirectionChange() =>
            _waitingForDirectionChange = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, 0, 0, _directionChangeTimeInterval.GetNextInterval())).Subscribe(_ => ChangeDirection());

        private void ChangeDirection()
        {
            var changeDelta = _directionChangeDeltaInDegrees.MinDelta +
                              (_directionChangeDeltaInDegrees.MaxDelta - _directionChangeDeltaInDegrees.MinDelta) * (float)_random.NextDouble();

            if (_random.Next(0, 2) == 1)
            {
                changeDelta *= -1;
            }

            _currentDirection = Quaternion.Euler(0, changeDelta, 0) * _currentDirection;

            WaitForDirectionChange();
        }

        public void Dispose()
        {
            _waitingForDirectionChange?.Dispose();
        }
    }
}