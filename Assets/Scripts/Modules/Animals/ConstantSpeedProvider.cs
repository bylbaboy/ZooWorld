namespace Modules.Animals
{
    public sealed class ConstantSpeedProvider : ISpeedProvider
    {
        private readonly float _speed;

        public ConstantSpeedProvider(float speed) =>
            _speed = speed;

        public float GetSpeed() =>
            _speed;

        public void Dispose()
        {
        }
    }
}