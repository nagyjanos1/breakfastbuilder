using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console.Ingredients;

public record Bacon : Ingredient, IFryableIngredient
{
    public Bacon(int id) : base(id)
    {
    }

    public string State { get; private set; } = FryableStates.Normal;

    public override string GetName()
    {
        return nameof(Bacon);
    }

    public void Fried()
    {
        State = FryableStates.Fried;

        $"The {Id} bacon is ready.".Dump();
    }
}