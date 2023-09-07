using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Modules.Animals;
using Modules.Animals.Entities;
using Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules
{
    public sealed class AnimalSpawnerModule : Module
    {
        private List<IAnimal> _animalsToSpawn;
        private IIntervalProvider<int> _intervalProvider;
        private IDisposable _spawning;

        public AnimalSpawnerModule(IAnimalSet setToSpawn, IIntervalProvider<int> intervalProvider)
        {
            _animalsToSpawn = setToSpawn.GetAnimals();
            _intervalProvider = intervalProvider;
        }

        public override Task Initialize(IServices services, CancellationTokenSource cancellationToken)
        {
            Spawn();

            return Task.CompletedTask;
        }

        private void Spawn()
        {
            var animal = new Snake();
            var prefab = animal.GetPrefab();
            var obj = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            
            WaitForSpawn();
        }

        private void WaitForSpawn()
        {
            _spawning = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, _intervalProvider.GetNextInterval()))
                .Subscribe(_ => Spawn());
        }

        public override void Dispose()
        {
            _spawning.Dispose();
        }
    }
}