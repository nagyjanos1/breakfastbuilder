using AsyncBreakfast.Console.Ingredients;
using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console.Instruments;

public class Fryer
{
    public const int MaxPanNumber = 4;

    private readonly Dictionary<int, bool> _panOccupation = new();

    public async Task HeatPanAsync(int which)
    {
        if (which < 0 && which >= MaxPanNumber)
        {
            throw new ArgumentOutOfRangeException($"{nameof(which)} does not exist");
        }

        if (_panOccupation.TryGetValue(which, out var isOccupied))
        {
            if (isOccupied)
            {
                throw new Exception($"It is occupied. {which}");
            }

            _panOccupation.Add(which, true);
        }
        
        $"Warming the pan {which}...".Dump();

        await Task.Delay(2000).ConfigureAwait(false);

        $"The pan {which} is heated.".Dump();
    }

    public async Task FryAsync<T>(params T[] ingredients) where T : Ingredient, IFryableIngredient
    {
        foreach (var ingredient in ingredients)
        {
            $"frying the {ingredient.GetName()} - {ingredient.Id} ...".Dump();

            await Task.Delay(3000).ConfigureAwait(false);

            ingredient.Fried();
        }
    }

    public async Task FryAsync<T>(T ingredient) where T : Ingredient, IFryableIngredient
    {
            $"frying the {ingredient.GetName()} - {ingredient.Id} ...".Dump();

            await Task.Delay(3000).ConfigureAwait(false);

            ingredient.Fried();
    }

    public async Task FryWithFlippingAsync<T>(params T[] ingredients) where T : Ingredient, IFryableIngredient
    {
        foreach (var ingredient in ingredients)
        {
            $"frying the {ingredient.GetName()} - {ingredient.Id} ...".Dump();

            await Task.Delay(3000).ConfigureAwait(false);

            $"flipping a slice of {ingredient.GetName()} - {ingredient.Id} and frying".Dump();

            await Task.Delay(1500).ConfigureAwait(false);

            ingredient.Fried();
        }
    }

    public async Task FryWithFlippingAsync<T>(T ingredient) where T : Ingredient, IFryableIngredient
    {
        $"frying the {ingredient.GetName()} - {ingredient.Id} ...".Dump();

        await Task.Delay(3000).ConfigureAwait(false);

        $"flipping a slice of {ingredient.GetName()} - {ingredient.Id} and frying".Dump();

        await Task.Delay(1500).ConfigureAwait(false);

        ingredient.Fried();
    }

}

