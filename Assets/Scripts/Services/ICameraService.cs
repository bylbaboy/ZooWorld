using UnityEngine;

namespace Services
{
    public interface ICameraService : IService
    {
        Camera GetCamera();
    }
}