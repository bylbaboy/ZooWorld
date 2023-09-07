using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Services;
using UnityEngine;

namespace Modules
{
    /// <summary>
    ///     The container of modules and services that is used for initialization of different scenes
    /// </summary>
    public abstract class Modules : MonoBehaviour
    {
        private List<IModule> _modules;
        private IServices _services;
        private CancellationTokenSource _cancellation;

        private async Task Initialize(CancellationTokenSource cancellationToken)
        {
            _modules = GetModules();
            foreach (var module in _modules)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                try
                {
                    await module.Initialize(_services, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    Debug.Log("Modules initialization was cancelled");
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        private void OnDestroy()
        {
            _cancellation.Cancel();

            foreach (var module in _modules)
            {
                module.Dispose();
            }

            _services.Dispose();
        }

        private async void Start()
        {
            _services = new Services.Services(new TypeHashList<IService>(GetServices()));

            _cancellation = new CancellationTokenSource();
            await Initialize(_cancellation);
        }

        protected virtual List<IModule> GetModules() =>
            new();

        protected virtual List<IService> GetServices() =>
            new();
    }
}