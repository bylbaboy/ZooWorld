using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Cysharp.Threading.Tasks.Linq;
using Modules.Animals;
using Modules.Animals.Entities;
using Services;
using UnityEngine;
using IDisposable = System.IDisposable;
using Object = UnityEngine.Object;

namespace Modules
{
    public sealed class AnimalSpawnerModule : Module
    {
        private IAnimalPicker _animalPicker;
        private List<IAnimal> _spawnedAnimals = new();
        private IIntervalProvider<int> _intervalProvider;
        private IDisposable _spawning;

        public AnimalSpawnerModule(IAnimalPicker animalPicker, IIntervalProvider<int> intervalProvider)
        {
            _animalPicker = animalPicker;
            _intervalProvider = intervalProvider;
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
            
            _spawnedAnimals.Add(animal);
            
            WaitForSpawn();
        }

        private void WaitForSpawn()
        {
            _spawning = UniTaskAsyncEnumerable.Timer(new TimeSpan(0, 0, 0, 0, _intervalProvider.GetNextInterval()))
                .Subscribe(_ => Spawn());
        }

        public override void Dispose()
        {
            _spawning.Dispose();

            foreach (var animal in _spawnedAnimals)
            {
                animal.Dispose();
            }
        }
    }
}