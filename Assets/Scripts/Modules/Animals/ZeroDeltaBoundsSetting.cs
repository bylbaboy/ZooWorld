namespace Modules.Animals
{
    public sealed class ZeroDeltaBoundsSetting : IDeltaBoundsSetting
    {
        private IDeltaBoundsSetting _delta = new DeltaBoundsSetting(0, 0);
        public float MinDelta => _delta.MinDelta;
        public float MaxDelta => _delta.MaxDelta;
    }
}