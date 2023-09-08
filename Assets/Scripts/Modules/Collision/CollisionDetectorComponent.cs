using Common;
using UnityEngine;

namespace Modules.Collision
{
    public sealed class CollisionDetectorComponent : MonoBehaviour
    {
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (collision.gameObject.layer != Constants.ANIMALS_LAYER)
            {
                return;
            }
            
            Messenger.Send(new CollisionMessage(gameObject, collision.gameObject));
        }
    }
}