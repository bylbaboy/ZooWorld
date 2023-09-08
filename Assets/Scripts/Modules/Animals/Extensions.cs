namespace Modules.Animals
{
    /// <summary>
    ///     Animal-related extensions
    /// </summary>
    public static class Extensions
    {
        public static bool IsPredator(this IAnimal animal) =>
            animal.GetPredationLevel() > 0;
    }
}