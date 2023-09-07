using System;

namespace Modules.Animals
{
    public sealed class DeltaBoundsSetting : IDeltaBoundsSetting
    {
        private float _minDelta;
        private float _maxDelta;

        public float MinDelta => _minDelta;
        public float MaxDelta => _maxDelta;

        public DeltaBoundsSetting(float minDelta, float maxDelta)
        {
            _minDelta = minDelta;
            _maxDelta = maxDelta;

            if (_maxDelta < _minDelta)
            {
                throw new Exception("Incorrect delta setting");
            }
        }
    }
}