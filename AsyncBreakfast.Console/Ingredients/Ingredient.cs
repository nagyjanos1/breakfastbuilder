namespace AsyncBreakfast.Console.Ingredients;

public abstract record Ingredient
{
    private static readonly Random _random = new((int)(DateTime.Now.Ticks / 1000));

    private readonly int _id;

    public string Id
    {
        get
        {
            return _id.ToString();
        }
    }

    public Ingredient()
    {
        _id = _random.Next();
    }

    protected Ingredient(int id)
    {
        _id = id;
    }

    protected Ingredient(string id)
    {
        _id = int.Parse(id);
    }

    public abstract string GetName();
}
