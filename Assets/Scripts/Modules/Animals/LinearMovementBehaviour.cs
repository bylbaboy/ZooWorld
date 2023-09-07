﻿using System;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Modules.Animals
{
    public sealed class LinearMovementBehaviour : MovementBehaviour
    {
        private IDisposable _updating;
        
        public LinearMovementBehaviour(ISpeedProvider speedProvider, IMovementDirectionProvider directionProvider) : base(speedProvider, directionProvider)
        {
        }

        protected override void OnInitialize()
        {
            _updating = UniTaskAsyncEnumerable.EveryUpdate().Subscribe(_ => Move());
        }

        protected override void OnDispose()
        {
            _updating?.Dispose();
        }

        private void Move()
        {
            var translation = DirectionProvider.GetDirection().normalized * SpeedProvider.GetSpeed() * Time.deltaTime;
            ObjectToMove.Translate(translation);
        }
    }
}