using UnityEngine;

namespace Services
{
    public sealed class CameraService : Service, ICameraService
    {
        private Camera _camera;
        
        public CameraService()
        {
            _camera = Object.FindObjectOfType<Camera>();
        }
        
        public Camera GetCamera() =>
            _camera;
    }
}