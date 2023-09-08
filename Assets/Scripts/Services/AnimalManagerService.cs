using System;
using Common;
using Modules.Animals;
using UnityEngine;

namespace Services
{
    /// <summary>
    /// Basic IAnimalManagerService implementation
    /// </summary>
    public sealed class AnimalManagerService : Service, IAnimalManagerService, IMessageListener<AnimalCreatedMessage>, IMessageListener<AnimalDiedMessage>
    {
        private TwoWayDictionary<IAnimal, GameObject> _animals = new();

        private void Register(IAnimal animal, GameObject obj)
        {
            var success = _animals.TryAdd(animal, obj);
            if (!success)
            {
                throw new Exception("Incorrect animal management logic");
            }
        }

        private void Remove(IAnimal animal)
        {
            animal.Dispose();
            _animals.Remove(animal);
        }

        public bool TryGetAnimal(GameObject obj, out IAnimal animal) =>
            _animals.TryGetKeyByValue(obj, out animal);

        public bool TryGetObject(IAnimal animal, out GameObject obj) =>
            _animals.TryGetValueByKey(animal, out obj);

        public override void Initialize(IServices services)
        {
            Messenger.Subscribe<AnimalCreatedMessage>(this);
            Messenger.Subscribe<AnimalDiedMessage>(this);
        }

        public override void Dispose()
        {
            Messenger.Unsubscribe<AnimalCreatedMessage>(this);
            Messenger.Unsubscribe<AnimalDiedMessage>(this);
            
            foreach (var animal in _animals.GetKeys())
            {
                animal.Dispose();
            }
        }

        public void OnMessage(AnimalCreatedMessage message)
        {
            Register(message.Animal, message.Object);
        }

        public void OnMessage(AnimalDiedMessage message)
        {
            Remove(message.Victim);
        }
    }
}