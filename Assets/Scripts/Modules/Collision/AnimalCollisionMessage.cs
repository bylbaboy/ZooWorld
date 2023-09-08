using UnityEngine;

namespace Modules.Collision
{
    /// <summary>
    ///     Notifies when some animals have collided
    /// </summary>
    public sealed class AnimalCollisionMessage
    {
        public readonly GameObject CollisionSource;
        public readonly GameObject CollisionTarget;

        public AnimalCollisionMessage(GameObject collisionSource, GameObject collisionTarget)
        {
            CollisionSource = collisionSource;
            CollisionTarget = collisionTarget;
        }
    }
}