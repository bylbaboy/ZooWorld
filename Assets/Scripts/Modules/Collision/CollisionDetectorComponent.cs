using System;
using Common;
using UnityEngine;

namespace Modules.Collision
{
    /// <summary>
    ///     Detects object collisions
    /// </summary>
    public sealed class CollisionDetectorComponent : MonoBehaviour
    {
        private void Awake()
        {
            if (gameObject.layer != Constants.ANIMALS_LAYER)
            {
                throw new Exception(nameof(CollisionDetectorComponent) + "added to the non-animal object");
            }
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (collision.gameObject.layer != Constants.ANIMALS_LAYER)
            {
                return;
            }

            Messenger.Send(new AnimalCollisionMessage(gameObject, collision.gameObject));
        }
    }
}