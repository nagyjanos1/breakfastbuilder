using AsyncBreakfast.Console.Ingredients;
using AsyncBreakfast.Console.Instruments;
using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console
{
    public class BreakfastBuilder : IBreakfastBuilder
    {
        private readonly Fryer _fryer;
        private readonly Toaster _toaster;

        public Breakfast Breakfast { get; private set; }

        public BreakfastBuilder()
        {
            Breakfast = new Breakfast();

            _fryer = new Fryer();
            _toaster = new Toaster();
        }

        public async Task<IBreakfastBuilder> InitAsync()
        {
            // Egyszerre indítjuk a sütőlapokat
            var panTasks = new[] { _fryer.HeatPanAsync(1), _fryer.HeatPanAsync(2) };
            await Task.WhenAll(panTasks).ConfigureAwait(false);

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddEggsAsync(params Egg[] eggs)
        {
            var crackedEggsTasks = eggs.Select(egg => egg.CrackAsync()).ToArray();
            var crackedEggs = await Task.WhenAll(crackedEggsTasks).ConfigureAwait(false);

            var friedEggsTasks = crackedEggs.Select(x => _fryer.FryAsync(x)).ToList();
            await Task.WhenAll(friedEggsTasks).ConfigureAwait(false);

            Breakfast?.Ingredients.AddRange(eggs);

            "Put eggs on plate".Dump();
            "eggs are ready".Dump();

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddBaconsAsync(params Bacon[] bacons)
        {
            var friedBaconTasks = bacons.Select(x => _fryer.FryWithFlippingAsync(x)).ToList();
            await Task.WhenAll(friedBaconTasks).ConfigureAwait(false);

            Breakfast?.Ingredients.AddRange(bacons);

            "bacon is ready".Dump();

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddToastsAsync(params Bread[] breads)
        {
            var breadPuttingTasks = breads.Select(x => _toaster.PutAsync(x)).ToList();
            await Task.WhenAll(breadPuttingTasks).ConfigureAwait(false);

            var toasts = await _toaster.Toast().ConfigureAwait(false);
            foreach (var toast in toasts)
            {
                await toast.ApplyButter().ConfigureAwait(false);
                await toast.ApplyJam().ConfigureAwait(false);
            }
            Breakfast?.Ingredients.AddRange(toasts);
            "toast is ready".Dump();

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddCoffeeAsync()
        {
            var cup = CoffeeMaker.Create();
            await PourAsync(cup).ConfigureAwait(false);
            Breakfast?.Ingredients.Add(cup);

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddJuiceAsync()
        {
            var oj = Juice.Create();
            await PourAsync(oj).ConfigureAwait(false);
            Breakfast?.Ingredients.Add(oj);

            System.Console.WriteLine("------");

            return this;
        }

        private async Task PourAsync(Liquid liquid)
        {
            await liquid.PourAsync().ConfigureAwait(false);

            $"{liquid.GetName()} is ready".Dump();
        }

    }
}
