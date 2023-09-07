namespace Modules.Animals
{
    public sealed class ZeroDeltaBoundsSetting : IDeltaBoundsSetting<int>
    {
        private IDeltaBoundsSetting<int> _delta = new DeltaBoundsSetting<int>(0, 0);
        public int MinDelta => _delta.MinDelta;
        public int MaxDelta => _delta.MaxDelta;
    }
}