using Common;

namespace Modules.Animals
{
    /// <summary>
    ///     Provides speed values
    /// </summary>
    public interface ISpeedProvider : IDisposable
    {
        float GetSpeed();

        void Initialize();
    }
}