namespace AsyncBreakfast.Console.Ingredients;

public record Juice : Liquid
{
    public override string GetName()
    {
        return nameof(Juice);
    }

    public static Juice Create()
    {
        return new Juice();
    }
}
