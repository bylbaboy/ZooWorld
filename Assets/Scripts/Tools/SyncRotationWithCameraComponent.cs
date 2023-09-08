using System;
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
            Sync();
        }

        private void Update()
        {
            Sync();
        }

        private void Sync()
        {
            transform.rotation = _cameraService.GetCamera().transform.rotation;
        }
    }
}