using UnityEngine;

namespace Services
{
    /// <summary>
    /// Basic ICameraService implementation
    /// </summary>
    public sealed class CameraService : Service, ICameraService
    {
        private readonly Camera _camera;
        
        public CameraService()
        {
            _camera = Object.FindObjectOfType<Camera>();
        }
        
        public Camera GetCamera() =>
            _camera;
    }
}