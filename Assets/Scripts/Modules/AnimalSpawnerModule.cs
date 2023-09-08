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
    /// <summary>
    ///     Controls animals spawning
    /// </summary>
    public sealed class AnimalSpawnerModule : Module
    {
        private readonly IAnimalFactory _animalFactory;
        private readonly IValuesProvider<int> _intervalsProvider;
        private readonly IBounds<Vector2> _spawnArea;
        private IDisposable _spawning;
        private readonly Transform _parentObject;

        public AnimalSpawnerModule(IAnimalFactory animalFactory, IValuesProvider<int> intervalsProvider,
            IBounds<Vector2> spawnArea)
        {
            _animalFactory = animalFactory;
            _intervalsProvider = intervalsProvider;
            _spawnArea = spawnArea;

            _parentObject = new GameObject("AnimalsParent").transform;
        }

        private void Spawn()
        {
            var animal = _animalFactory.CreateNext();
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
            _spawning = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, _intervalsProvider.GetNext()))
                .Subscribe(_ => Spawn());
        }

        public override void Dispose()
        {
            _spawning.Dispose();
        }

        public override Task Initialize(IServices services, CancellationTokenSource cancellationToken)
        {
            Spawn();

            return Task.CompletedTask;
        }
    }
}