using System.Collections.Generic;
using Modules.Animals;
using Services;

namespace Modules
{
    public sealed class ZooModules : Modules
    {
        protected override List<IModule> GetModules() =>
            new()
            {
                new AnimalSpawnerModule(new BasicAnimalSet(), new ConstantIntervalProvider(3)),
            };

        protected override List<IService> GetServices() =>
            base.GetServices();
    }
}