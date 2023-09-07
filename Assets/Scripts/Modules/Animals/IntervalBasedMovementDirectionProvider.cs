using System;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class IntervalBasedMovementDirectionProvider : IMovementDirectionProvider
    {
        private IDeltaBoundsSetting _directionChangeBounds;
        private IIntervalProvider _intervalProvider;
        
        public Vector3 GetDirection() =>
            throw new System.NotImplementedException();

        public IntervalBasedMovementDirectionProvider(IDeltaBoundsSetting directionChangeBounds, IIntervalProvider intervalProvider)
        {
            _directionChangeBounds = directionChangeBounds;
            _intervalProvider = intervalProvider;
            
            UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, intervalProvider.GetNextInterval()))
        }
    }
}