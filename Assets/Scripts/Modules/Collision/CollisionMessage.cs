using UnityEngine;

namespace Modules.Collision
{
    public sealed class CollisionMessage
    {
        public readonly GameObject _collisionSource;
        public readonly GameObject _collisionTarget;

        public CollisionMessage(GameObject collisionSource, GameObject collisionTarget)
        {
            _collisionSource = collisionSource;
            _collisionTarget = collisionTarget;
        }
    }
}