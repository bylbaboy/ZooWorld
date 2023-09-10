using Common;
using Services;

namespace Modules.Animals
{
    /// <summary>
    ///     Animal IFactory implementation
    /// </summary>
    public interface IAnimalFactory : IFactory<IAnimal>, IInitializable<IServices>
    {
    }
}