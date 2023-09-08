using Services;
using UnityEngine;

namespace Tools
{
    public sealed class SyncRotationWithCameraComponent : MonoBehaviour
    {
        private ICameraService _cameraService;

        public void Initialize(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }
        
        private void Start()
        {
            transform.rotation = _cameraService.GetCamera().transform.rotation;
        }
    }
}