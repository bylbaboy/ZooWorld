using System;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Modules.Animals;
using Modules.Collision;
using Services;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Modules
{
    public sealed class DeathModule : Module, IMessageListener<CollisionMessage>
    {
        private IAnimalManagerService _manager;
        
        public override Task Initialize(IServices services, CancellationTokenSource cancellationToken)
        {
            _manager = services.Get<IAnimalManagerService>();
            
            Messenger.Subscribe(this);
            
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            Messenger.Unsubscribe(this);
        }

        private void CheckForDeath(GameObject obj1, GameObject obj2)
        {
            var success1 = _manager.TryGetAnimal(obj1, out var animal1);
            var success2 = _manager.TryGetAnimal(obj2, out var animal2);

            if (success1 == false || success2 == false)
            {
                return;
            }
            
            var predation1 = animal1.GetPredationLevel();
            var predation2 = animal2.GetPredationLevel();

            if (predation1 == predation2)
            {
                if (predation1 == 0)
                {
                    return;
                }
                else
                {
                    Kill(Random.Range(0, 2) == 1 ? animal1 : animal2);
                }
            }
            else if (predation1 > predation2)
            {
                Kill(animal2);
            }
            else if (predation1 < predation2)
            {
                Kill(animal1);
            }
        }

        public void OnMessage(CollisionMessage message)
        {
            CheckForDeath(message.CollisionSource, message.CollisionTarget);
        }

        private void Kill(IAnimal animal)
        {
            var success = _manager.TryGetObject(animal, out var obj);
            if (!success)
            {
                throw new Exception("Incorrect death logic");
            }
            Object.Destroy(obj);
            
            Messenger.Send(new AnimalDiedMessage(animal));
        }
    }
}