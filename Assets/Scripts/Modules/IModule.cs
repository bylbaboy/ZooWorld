using System.Threading;
using System.Threading.Tasks;
using Common;
using Services;

namespace Modules
{
    /// <summary>
    ///     Executes some logically separated functionality
    ///     Can't be used by other scripts, so can be easily removed
    /// </summary>
    public interface IModule : IDisposable
    {
        Task Initialize(IServices services, CancellationTokenSource cancellationToken);
    }
}