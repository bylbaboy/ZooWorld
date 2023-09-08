using System.Threading;
using System.Threading.Tasks;
using Services;

namespace Modules
{
    /// <summary>
    ///     Basic IModule implementation
    /// </summary>
    public abstract class Module : IModule
    {
        public virtual async Task Initialize(IServices services, CancellationTokenSource cancellationToken)
        {
            await Task.CompletedTask;
        }

        public abstract void Dispose();
    }
}