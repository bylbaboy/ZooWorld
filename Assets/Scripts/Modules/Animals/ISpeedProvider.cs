using Common;

namespace Modules.Animals
{
    /// <summary>
    /// Provides speed values
    /// </summary>
    public interface ISpeedProvider : IDisposable
    {
        void Initialize();
        float GetSpeed();
    }
}