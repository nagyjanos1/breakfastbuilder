namespace AsyncBreakfast.Console.Ingredients;

public record Coffee : Liquid
{
    public override string GetName()
    {
        return nameof(Coffee);
    }
}
