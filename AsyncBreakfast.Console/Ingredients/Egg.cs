using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console.Ingredients;

public record Egg : Ingredient, IFryableIngredient
{
    public Egg(int id) : base(id)
    {
    }

    public string State { get; private set; } = FryableStates.Normal;

    public override string GetName()
    {
        return nameof(Egg);
    }

    public async Task<Egg> CrackAsync()
    {
        $"cracking {Id} egg".Dump();

        await Task.Delay(200).ConfigureAwait(false);

        return this with 
        { 
            State = "Cracked" 
        };
    }

    public void Fried()
    {
        State = FryableStates.Fried;

        $"The {Id} egg is ready.".Dump();
    }
}
