namespace Modules.Animals
{
    public sealed class ConstantIntervalProvider : IIntervalProvider<int>
    {
        private int _interval;

        public ConstantIntervalProvider(int interval) =>
            _interval = interval;

        public int GetNextInterval() =>
            _interval;
    }
}