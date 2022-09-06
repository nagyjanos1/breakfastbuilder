using AsyncBreakfast.Console.Ingredients;
using AsyncBreakfast.Console.Instruments;
using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console
{
    public class GoodBreakfastBuilder : IBreakfastBuilder
    {
        private readonly Fryer _fryer;
        private readonly Toaster _toaster;

        public Breakfast? Breakfast { get; private set; }

        public GoodBreakfastBuilder()
        {
            _fryer = new Fryer();
            _toaster = new Toaster();

            Breakfast = new Breakfast();
        }

        public async Task<IBreakfastBuilder> AddBaconsAsync(params Bacon[] bacons)
        {
            var friedBacon = bacons.Select(x => _fryer.FryWithFlippingAsync(x)).ToList();
            await Task.WhenAll(friedBacon).ConfigureAwait(false);

            Breakfast?.Ingredients.AddRange(bacons);

            "Bacon is ready".Dump();

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

        public async Task<IBreakfastBuilder> AddEggsAsync(params Egg[] eggs)
        {
            var crackedEggs = new List<Egg>();
            foreach (var egg in eggs)
            {
                var cracked = await egg.CrackAsync().ConfigureAwait(false);
                crackedEggs.Add(cracked);
            }

            await _fryer.FryAsync(crackedEggs.ToArray()).ConfigureAwait(false);

            Breakfast?.Ingredients.AddRange(crackedEggs);
    
            "Eggs are ready".Dump();

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

        public async Task<IBreakfastBuilder> AddToastsAsync(params Bread[] breads)
        {
            var tasks = breads.Select(bread => _toaster.PutAsync(bread)).ToList();
            await Task.WhenAll(tasks).ConfigureAwait(false);

            var toasts = await _toaster.Toast().ConfigureAwait(false);
            foreach (var toast in toasts)
            {
                await toast.ApplyButter().ConfigureAwait(false);
                await toast.ApplyJam().ConfigureAwait(false);

                Breakfast?.Ingredients.Add(toast);
            }
            "Toast is ready".Dump();

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> InitAsync()
        {
            await _fryer.HeatPanAsync(1).ConfigureAwait(false);
            await _fryer.HeatPanAsync(2).ConfigureAwait(false);

            System.Console.WriteLine("------");

            return this;
        }

        private async Task PourAsync(Liquid liquid)
        {
            await liquid.PourAsync().ConfigureAwait(false);

            $"The {liquid.GetName()} is ready".Dump();
        }
    }
}
