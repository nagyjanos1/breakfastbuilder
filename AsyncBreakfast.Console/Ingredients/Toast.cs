using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console.Ingredients;

public record Toast : Ingredient
{
    public Toast() : base() { }

    public Toast(Bread bread) : base(bread.Id)
    {

    }

    public override string GetName()
    {
        return nameof(Toast);
    }

    public async Task ApplyJam()
    {
        $"Putting jam on the toast ({Id})".Dump();

        await Task.Delay(1000).ConfigureAwait(false);
    }

    public async Task ApplyButter()
    {
        $"Putting butter on the toast ({Id})".Dump();

        await Task.Delay(1000).ConfigureAwait(false);
    }
}