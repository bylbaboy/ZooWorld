using System;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Modules.Animals
{
    public sealed class IntervalBased2DMovementDirectionProvider : IMovementDirectionProvider
    {
        private IDeltaBoundsSetting<float> _changeBounds;
        private IIntervalProvider<int> _changeInterval;
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

        public IntervalBased2DMovementDirectionProvider(IDeltaBoundsSetting<float> changeBounds, IIntervalProvider<int> changeInterval)
        {
            _changeBounds = changeBounds;
            _changeInterval = changeInterval;
        }

        private void WaitForDirectionChange() =>
            _waitingForDirectionChange = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, _changeInterval.GetNextInterval())).Subscribe(_ => ChangeDirection());

        private void ChangeDirection()
        {
            var changeDelta = _changeBounds.MinDelta +
                              (_changeBounds.MaxDelta - _changeBounds.MinDelta) * (float)_random.NextDouble();

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