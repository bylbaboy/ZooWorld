using System.Collections.Generic;
using Common;
using Common.Values;
using Modules.Animals;
using Services;

namespace Modules
{
    /// <summary>
    /// Controls zoo scene modules
    /// </summary>
    public sealed class ZooModules : Modules
    {
        protected override List<IModule> GetModules() =>
            new()
            {
                new AnimalSpawnerModule(
                    new RandomAnimalFactory(),
                    new BoundedValuesProvider<int>(new Bounds<int>(1, 2), new RandomIntPicker()),
                    Constants.SPAWN_AREA
                ),
                new DeathModule(),
                new EmotionModule(new ResourcesPrefabProvider("KillEmotion")),
                new StatsCounterModule(),
            };

        protected override List<IService> GetServices() =>
            new()
            {
                new AnimalManagerService(),
                new CameraService()
            };
    }
}