namespace Modules.Animals
{
    public static class Extensions
    {
        public static bool IsPredator(this IAnimal animal) =>
            animal.GetPredationLevel() > 0;
    }
}