using System.Collections.Generic;
using Common.Parameters;
using Modules.Animals;
using Services;

namespace Modules
{
    public sealed class ZooModules : Modules
    {
        protected override List<IModule> GetModules() =>
            new()
            {
                new AnimalSpawnerModule(
                    new RandomAnimalPicker(), 
                    new BoundedValuesProvider<int>(new Bounds<int>(1000, 2000), new RandomIntPicker())),
            };

        protected override List<IService> GetServices() =>
            base.GetServices();
    }
}