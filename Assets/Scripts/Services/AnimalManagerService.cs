using System;
using Common;
using Modules.Animals;
using UnityEngine;

namespace Services
{
    public sealed class AnimalManagerService : Service, IAnimalManagerService, IMessageListener<AnimalCreatedMessage>
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

        public IAnimal GetAnimal(GameObject obj)
        {
            var success = _animals.TryGetKeyByValue(obj, out var animal);

            if (!success)
            {
                throw new Exception("Animal was not found");
            }
            
            return animal;
        }

        public override void Initialize(IServices services)
        {
            Messenger.Subscribe(this);
        }

        public override void Dispose()
        {
            Messenger.Unsubscribe(this);
            
            foreach (var animal in _animals.GetKeys())
            {
                animal.Dispose();
            }
        }

        public void OnMessage(AnimalCreatedMessage message)
        {
            Register(message.Animal, message.Object);
        }
    }
}