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
                new AnimalSpawnerModule(new RandomAnimalPicker(), new ConstantValuesProvider<int>(3000)),
            };

        protected override List<IService> GetServices() =>
            base.GetServices();
    }
}