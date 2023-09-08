﻿namespace Modules.Animals
{
    /// <summary>
    /// Constant ISpeedProvider implementation
    /// </summary>
    public sealed class ConstantSpeedProvider : ISpeedProvider
    {
        private readonly float _speed;

        public ConstantSpeedProvider(float speed) =>
            _speed = speed;

        public void Initialize()
        {
        }

        public float GetSpeed() =>
            _speed;

        public void Dispose()
        {
        }
    }
}