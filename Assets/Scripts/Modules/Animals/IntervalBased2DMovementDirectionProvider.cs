using System;
using Common.Values;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using Random = System.Random;

namespace Modules.Animals
{
    /// <summary>
    ///     2D interval-based IMovementDirectionProvider implementation
    /// </summary>
    public sealed class IntervalBased2DMovementDirectionProvider : IMovementDirectionProvider
    {
        private readonly IValuesProvider<float> _directionChangeDeltaInDegrees;
        private readonly IValuesProvider<int> _directionChangeTimeInterval;
        private IMovementDirectionCorrector _directionCorrector;
        private Vector3 _currentDirection;
        private IDisposable _waitingForDirectionChange;
        private Random _random;

        public IntervalBased2DMovementDirectionProvider(IValuesProvider<float> directionChangeDeltasProvider,
            IValuesProvider<int> directionChangeDelaysProvider)
        {
            _directionChangeDeltaInDegrees = directionChangeDeltasProvider;
            _directionChangeTimeInterval = directionChangeDelaysProvider;
        }

        public void Dispose()
        {
            _waitingForDirectionChange?.Dispose();
        }

        public Vector3 GetDirection() =>
            _currentDirection;

        public void Initialize(Transform obj)
        {
            _random = new Random();
            _currentDirection = Quaternion.Euler(0, _random.Next(0, 360), 0) * Vector3.forward;
            _directionCorrector.Initialize(obj);

            WaitForDirectionChange();
        }

        public IMovementDirectionProvider SetCorrector(IMovementDirectionCorrector directionCorrector)
        {
            _directionCorrector = directionCorrector;
            return this;
        }

        private void ChangeDirection()
        {
            var changeDelta = _directionChangeDeltaInDegrees.GetNext();

            if (_random.Next(0, 2) == 1)
            {
                changeDelta *= -1;
            }

            var newDirection = Quaternion.Euler(0, changeDelta, 0) * _currentDirection;
            var correctedDirection = _directionCorrector.Correct(newDirection);
            _currentDirection = correctedDirection;

            WaitForDirectionChange();
        }

        private void WaitForDirectionChange() =>
            _waitingForDirectionChange = UniTaskAsyncEnumerable
                .Timer(new TimeSpan(0, 0, 0, 0, _directionChangeTimeInterval.GetNext()))
                .Subscribe(_ => ChangeDirection());
    }
}