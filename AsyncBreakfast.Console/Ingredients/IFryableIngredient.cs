namespace AsyncBreakfast.Console.Ingredients;

public class FryableStates
{
    public const string Normal = nameof(Normal);
    public const string Fried = nameof(Fried);
}

public interface IFryableIngredient
{
    string State { get; }

    void Fried();
}