using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Modules.Animals;
using Services;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules
{
    /// <summary>
    ///     Controls emotions showing
    /// </summary>
    public sealed class EmotionModule : Module, IMessageListener<AnimalDiedMessage>
    {
        private readonly IPrefabProvider _prefabProvider;
        private IAnimalManagerService _manager;
        private ICameraService _camera;

        public EmotionModule(IPrefabProvider prefabProvider) =>
            _prefabProvider = prefabProvider;

        public void OnMessage(AnimalDiedMessage message)
        {
            ShowEmotion(message.Killer);
        }

        private IEnumerator DestroyAfterDelay(Object obj)
        {
            yield return new WaitForSeconds(3);
            Object.Destroy(obj);
        }

        private void ShowEmotion(IAnimal animal)
        {
            var success = _manager.TryGetObject(animal, out var obj);

            if (!success)
            {
                throw new Exception("Incorrect killer animal");
            }

            var emotion = Object.Instantiate(_prefabProvider.GetPrefab(), obj.transform, false);
            emotion.AddComponent<CoroutineHolderComponent>().StartCoroutine(DestroyAfterDelay(emotion));
            emotion.AddComponent<SyncRotationWithCameraComponent>().Initialize(_camera);
        }

        public override void Dispose()
        {
            Messenger.Unsubscribe(this);
        }

        public override Task Initialize(IServices services, CancellationTokenSource cancellationToken)
        {
            _camera = services.Get<ICameraService>();
            _manager = services.Get<IAnimalManagerService>();
            Messenger.Subscribe(this);
            return Task.CompletedTask;
        }
    }
}