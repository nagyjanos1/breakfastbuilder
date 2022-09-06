namespace AsyncBreakfast.Console.Ingredients;

public record Bread : Ingredient
{
    public Bread(int id) : base(id)
    {
    }

    public override string GetName()
    {
        return nameof(Bread);
    }
}

