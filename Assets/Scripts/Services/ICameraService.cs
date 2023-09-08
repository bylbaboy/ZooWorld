using UnityEngine;

namespace Services
{
    /// <summary>
    ///     Provides access to the camera
    /// </summary>
    public interface ICameraService : IService
    {
        Camera GetCamera();
    }
}