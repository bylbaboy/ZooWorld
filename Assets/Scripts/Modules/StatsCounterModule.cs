using System.Threading;
using System.Threading.Tasks;
using Common;
using Modules.Animals;
using Modules.Stats;
using Services;
using UnityEngine;

namespace Modules
{
    public sealed class StatsCounterModule : Module, IMessageListener<AnimalDiedMessage>
    {
        private int _preysDied = 0;
        private int _predatorsDied = 0;

        private TextModificationComponent _preysDiedText;
        private TextModificationComponent _predatorsDiedText;

        public override Task Initialize(IServices services, CancellationTokenSource cancellationToken)
        {
            _preysDiedText = Object.FindObjectOfType<PreysDiedTargetComponent>()
                .GetComponent<TextModificationComponent>();
            
            _predatorsDiedText = Object.FindObjectOfType<PredatorsDiedTargetComponent>()
                .GetComponent<TextModificationComponent>();
            
            Messenger.Subscribe(this);
            
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            Messenger.Unsubscribe(this);
        }

        private void CountAnimal(IAnimal animal)
        {
            if (animal.IsPredator())
            {
                _predatorsDied++;
            }
            else
            {
                _preysDied++;
            }

            UpdateStats();
        }

        private void UpdateStats()
        {
            _preysDiedText.UpdateText("" + _preysDied);
            _predatorsDiedText.UpdateText("" + _predatorsDied);
        }

        public void OnMessage(AnimalDiedMessage message)
        {
            CountAnimal(message.Victim);
        }
    }
}