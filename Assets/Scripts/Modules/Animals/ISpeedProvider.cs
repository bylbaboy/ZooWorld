using Common;

namespace Modules.Animals
{
    public interface ISpeedProvider : IDisposable
    {
        void Initialize();
        float GetSpeed();
    }
}