using System;
using Common.Values;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class IntervalBased2DMovementDirectionProvider : IMovementDirectionProvider
    {
        private readonly IValuesProvider<float> _directionChangeDeltaInDegrees;
        private readonly IValuesProvider<int> _directionChangeTimeInterval;
        private Vector3 _currentDirection;
        private IDisposable _waitingForDirectionChange;
        private System.Random _random;

        public void Initialize()
        {
            _random = new System.Random();
            _currentDirection = Quaternion.Euler(0, _random.Next(0, 360), 0) * Vector3.forward;
            
            WaitForDirectionChange();
        }

        public Vector3 GetDirection() =>
            _currentDirection;

        public IntervalBased2DMovementDirectionProvider(IValuesProvider<float> directionChangeDeltasProvider, IValuesProvider<int> directionChangeDelaysProvider)
        {
            _directionChangeDeltaInDegrees = directionChangeDeltasProvider;
            _directionChangeTimeInterval = directionChangeDelaysProvider;
        }

        private void WaitForDirectionChange() =>
            _waitingForDirectionChange = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, 0, 0, _directionChangeTimeInterval.GetNext())).Subscribe(_ => ChangeDirection());

        private void ChangeDirection()
        {
            var changeDelta = _directionChangeDeltaInDegrees.GetNext();

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