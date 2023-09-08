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
    /// <summary>
    /// Controls death process
    /// </summary>
    public sealed class DeathModule : Module, IMessageListener<AnimalCollisionMessage>
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
                    if (Random.Range(0, 2) == 1)
                    {
                        Kill(animal2, animal1);
                    }
                    else if (predation1 < predation2)
                    {
                        Kill(animal1, animal2);
                    }
                }
            }
            else if (predation1 > predation2)
            {
                Kill(animal2, animal1);
            }
            else if (predation1 < predation2)
            {
                Kill(animal1, animal2);
            }
        }

        public void OnMessage(AnimalCollisionMessage message)
        {
            CheckForDeath(message.CollisionSource, message.CollisionTarget);
        }

        private void Kill(IAnimal victim, IAnimal killer)
        {
            var success = _manager.TryGetObject(victim, out var obj);
            if (!success)
            {
                throw new Exception("Incorrect death logic");
            }
            Object.Destroy(obj);
            
            Messenger.Send(new AnimalDiedMessage(victim, killer));
        }
    }
}