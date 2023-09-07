using Common;

namespace Modules.Animals
{
    public interface ISpeedProvider : IDisposable
    {
        float GetSpeed();
    }
}