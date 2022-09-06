using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console.Ingredients;

public abstract record Liquid : Ingredient
{
    public virtual async Task PourAsync()
    {
        $"Pouring {GetName()}".Dump();

        await Task.Delay(100).ConfigureAwait(false);
    }
}