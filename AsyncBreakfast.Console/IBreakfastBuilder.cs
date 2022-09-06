using AsyncBreakfast.Console.Ingredients;

namespace AsyncBreakfast.Console
{
    public interface IBreakfastBuilder
    {
        Task<IBreakfastBuilder> InitAsync();
        Task<IBreakfastBuilder> AddEggsAsync(params Egg[] eggs);
        Task<IBreakfastBuilder> AddBaconsAsync(params Bacon[] bacons);
        Task<IBreakfastBuilder> AddToastsAsync(params Bread[] breads);
        Task<IBreakfastBuilder> AddCoffeeAsync();
        Task<IBreakfastBuilder> AddJuiceAsync();

        Breakfast Breakfast { get; }
    }
}
