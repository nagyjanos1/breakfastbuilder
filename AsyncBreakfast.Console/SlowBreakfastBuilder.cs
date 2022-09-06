using AsyncBreakfast.Console.Ingredients;
using AsyncBreakfast.Console.Instruments;
using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console
{

    public class SlowBreakfastBuilder : IBreakfastBuilder
    {
        private readonly Fryer _fryer;
        private readonly Toaster _toaster;

        public Breakfast? Breakfast { get; private set; }

        public SlowBreakfastBuilder()
        {
            _fryer = new Fryer();
            _toaster = new Toaster();

            Breakfast = new Breakfast();
        }

        public async Task<IBreakfastBuilder> InitAsync()
        {
            await _fryer.HeatPanAsync(1).ConfigureAwait(false); 
            await _fryer.HeatPanAsync(2).ConfigureAwait(false);

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddEggsAsync(params Egg[] eggs)
        {
            foreach (var egg in eggs)
            {
                var crackedEgg = await egg.CrackAsync().ConfigureAwait(false);
                await _fryer.FryAsync(crackedEgg).ConfigureAwait(false);

                Breakfast?.Ingredients.Add(egg);
            }         
            "Eggs are ready".Dump();

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddBaconsAsync(params Bacon[] bacons)
        {
            foreach (var bacon in bacons)
            {
                await _fryer.FryWithFlippingAsync(bacon).ConfigureAwait(false);

                Breakfast?.Ingredients.Add(bacon);
            }                        
            "Bacon is ready".Dump();

            System.Console.WriteLine("------");

            return this;
        }

        public async Task<IBreakfastBuilder> AddToastsAsync(params Bread[] breads)
        {
            foreach (var bacon in breads)
            {
                await _toaster.PutAsync(bacon).ConfigureAwait(false);
            }

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

            $"The {liquid.GetName()} is ready".Dump();
        }
    }
}
