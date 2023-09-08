using System;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Values;
using Cysharp.Threading.Tasks.Linq;
using Modules.Animals;
using Services;
using UnityEngine;
using IDisposable = System.IDisposable;
using Object = UnityEngine.Object;

namespace Modules
{
    public sealed class AnimalSpawnerModule : Module
    {
        private IAnimalPicker _animalPicker;
        private IValuesProvider<int> _intervalsProvider;
        private IDisposable _spawning;

        public AnimalSpawnerModule(IAnimalPicker animalPicker, IValuesProvider<int> intervalsProvider)
        {
            _animalPicker = animalPicker;
            _intervalsProvider = intervalsProvider;
        }

        public override Task Initialize(IServices services, CancellationTokenSource cancellationToken)
        {
            Spawn();

            return Task.CompletedTask;
        }

        private void Spawn()
        {
            var animal = _animalPicker.GetNext();
            var prefab = animal.GetPrefab();
            var obj = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);

            if (animal is IInitializable<Transform> initializable)
            {
                initializable.Initialize(obj.transform);
            }

            Messenger.Send(new AnimalCreatedMessage(animal, obj));
            
            WaitForSpawn();
        }

        private void WaitForSpawn()
        {
            _spawning = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, 0, 0, _intervalsProvider.GetNext()))
                .Subscribe(_ => Spawn());
        }

        public override void Dispose()
        {
            _spawning.Dispose();
        }
    }
}