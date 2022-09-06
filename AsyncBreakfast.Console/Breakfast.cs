using AsyncBreakfast.Console.Ingredients;

namespace AsyncBreakfast.Console
{
    public class Breakfast
    {
        public List<Ingredient> Ingredients { get; }

        public Breakfast()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
