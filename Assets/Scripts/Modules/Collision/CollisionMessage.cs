using UnityEngine;

namespace Modules.Collision
{
    public sealed class CollisionMessage
    {
        public readonly GameObject CollisionSource;
        public readonly GameObject CollisionTarget;

        public CollisionMessage(GameObject collisionSource, GameObject collisionTarget)
        {
            CollisionSource = collisionSource;
            CollisionTarget = collisionTarget;
        }
    }
}