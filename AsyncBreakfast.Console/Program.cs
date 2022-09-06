using AsyncBreakfast.Console;
using AsyncBreakfast.Console.Ingredients;
using AsyncBreakfast.Console.Utils;

var start = DateTime.Now;
IBreakfastBuilder slowBreakfastBuilder = new SlowBreakfastBuilder();
slowBreakfastBuilder = await slowBreakfastBuilder.InitAsync().ConfigureAwait(false);
slowBreakfastBuilder = await slowBreakfastBuilder.AddBaconsAsync(new[] { new Bacon(1), new Bacon(2), new Bacon(3), new Bacon(4), new Bacon(5) }).ConfigureAwait(false);
slowBreakfastBuilder = await slowBreakfastBuilder.AddEggsAsync(new[] { new Egg(1), new Egg(2), new Egg(3), new Egg(4), new Egg(5) }).ConfigureAwait(false);
slowBreakfastBuilder = await slowBreakfastBuilder.AddToastsAsync(new[] { new Bread(1), new Bread(2), new Bread(3), new Bread(4), new Bread(5) }).ConfigureAwait(false);
slowBreakfastBuilder = await slowBreakfastBuilder.AddJuiceAsync().ConfigureAwait(false);
slowBreakfastBuilder = await slowBreakfastBuilder.AddCoffeeAsync().ConfigureAwait(false);
var stop = DateTime.Now;
"Breakfast is ready!".Dump();

$"Processing time: {(stop - start).TotalSeconds}".Dump();

Console.WriteLine("--------------------------------------------------------------------");

foreach (var ingredient in slowBreakfastBuilder.Breakfast.Ingredients)
{
    $"{ingredient.GetName()} - {ingredient.Id}".Dump();
    if (ingredient is IFryableIngredient)
    {
        $"State: {((IFryableIngredient)ingredient).State}".Dump();
    }
}

Console.WriteLine("--------------------------------------------------------------------");
Console.WriteLine("--------------------------------------------------------------------");

start = DateTime.Now;
IBreakfastBuilder breakfastBuilder = new BreakfastBuilder();
breakfastBuilder = await breakfastBuilder.InitAsync().ConfigureAwait(false);
breakfastBuilder = await breakfastBuilder.AddBaconsAsync(new[] { new Bacon(1), new Bacon(2), new Bacon(3), new Bacon(4), new Bacon(5) }).ConfigureAwait(false);
breakfastBuilder = await breakfastBuilder.AddEggsAsync(new[] { new Egg(1), new Egg(2), new Egg(3), new Egg(4), new Egg(5) }).ConfigureAwait(false);
breakfastBuilder = await breakfastBuilder.AddToastsAsync(new[] { new Bread(1), new Bread(2), new Bread(3), new Bread(4), new Bread(5) }).ConfigureAwait(false);
breakfastBuilder = await breakfastBuilder.AddJuiceAsync().ConfigureAwait(false);
breakfastBuilder = await breakfastBuilder.AddCoffeeAsync().ConfigureAwait(false);
stop = DateTime.Now;
"Breakfast is ready!".Dump();

$"Processing time: {(stop - start).TotalSeconds}".Dump();

Console.WriteLine("--------------------------------------------------------------------");

foreach (var ingredient in breakfastBuilder.Breakfast.Ingredients)
{
    $"{ingredient.GetName()} - {ingredient.Id}".Dump();
    if (ingredient is IFryableIngredient)
    {
        $"State: {((IFryableIngredient)ingredient).State}".Dump();
    }
}

Console.WriteLine("--------------------------------------------------------------------");
Console.WriteLine("--------------------------------------------------------------------");

start = DateTime.Now;
IBreakfastBuilder goodBreakfastBuilder = new GoodBreakfastBuilder();
goodBreakfastBuilder = await goodBreakfastBuilder.InitAsync().ConfigureAwait(false);
goodBreakfastBuilder = await goodBreakfastBuilder.AddBaconsAsync(new[] { new Bacon(1), new Bacon(2), new Bacon(3), new Bacon(4), new Bacon(5) }).ConfigureAwait(false);
goodBreakfastBuilder = await goodBreakfastBuilder.AddEggsAsync(new[] { new Egg(1), new Egg(2), new Egg(3), new Egg(4), new Egg(5) }).ConfigureAwait(false);
goodBreakfastBuilder = await goodBreakfastBuilder.AddToastsAsync(new[] { new Bread(1), new Bread(2), new Bread(3), new Bread(4), new Bread(5) }).ConfigureAwait(false);
goodBreakfastBuilder = await goodBreakfastBuilder.AddJuiceAsync().ConfigureAwait(false);
goodBreakfastBuilder = await goodBreakfastBuilder.AddCoffeeAsync().ConfigureAwait(false);
stop = DateTime.Now;
"Breakfast is ready!".Dump();

$"Processing time: {(stop - start).TotalSeconds}".Dump();

Console.WriteLine("--------------------------------------------------------------------");

foreach (var ingredient in goodBreakfastBuilder.Breakfast.Ingredients)
{
    $"{ingredient.GetName()} - {ingredient.Id}".Dump();
    if (ingredient is IFryableIngredient)
    {
        $"State: {((IFryableIngredient)ingredient).State}".Dump();
    }
}

Console.WriteLine("--------------------------------------------------------------------");
Console.WriteLine("--------------------------------------------------------------------");

Console.ReadKey();