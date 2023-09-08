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
using Random = UnityEngine.Random;

namespace Modules
{
    public sealed class AnimalSpawnerModule : Module
    {
        private IAnimalPicker _animalPicker;
        private IValuesProvider<int> _intervalsProvider;
        private IBounds<Vector2> _spawnArea;
        private IDisposable _spawning;
        private Transform _parentObject;

        public AnimalSpawnerModule(IAnimalPicker animalPicker, IValuesProvider<int> intervalsProvider, IBounds<Vector2> spawnArea)
        {
            _animalPicker = animalPicker;
            _intervalsProvider = intervalsProvider;
            _spawnArea = spawnArea;
            
            _parentObject = new GameObject("AnimalsParent").transform;
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
            var randomPosition = new Vector3(
                Random.Range(_spawnArea.Min.x, _spawnArea.Max.x),
                0,
                Random.Range(_spawnArea.Min.y, _spawnArea.Max.y)
            );
            
            var obj = Object.Instantiate(prefab, randomPosition, Quaternion.identity, _parentObject);

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