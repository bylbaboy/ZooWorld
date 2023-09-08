using Services;
using UnityEngine;

namespace Tools
{
    /// <summary>
    ///     Copies rotation from the camera component
    /// </summary>
    public sealed class SyncRotationWithCameraComponent : MonoBehaviour
    {
        private ICameraService _cameraService;

        public void Initialize(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        private void Start()
        {
            Sync();
        }

        private void Sync()
        {
            transform.rotation = _cameraService.GetCamera().transform.rotation;
        }

        private void Update()
        {
            Sync();
        }
    }
}