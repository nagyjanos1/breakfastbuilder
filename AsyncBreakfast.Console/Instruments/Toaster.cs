using AsyncBreakfast.Console.Ingredients;
using AsyncBreakfast.Console.Utils;

namespace AsyncBreakfast.Console.Instruments;

public class Toaster
{
    public readonly List<Bread> _breads;

    public Toaster()
    {
        _breads = new List<Bread>();
    }

    public async Task PutAsync(params Bread[] slices)
    {
        for (int slice = 0; slice < slices.Length; slice++)
        {
            $"Putting a {slice}. slice of bread in the toaster".Dump();

            _breads.Add(slices[slice]);

            await Task.Delay(200).ConfigureAwait(false);
        }
    }

    public async Task PutAsync(Bread slice)
    {
        $"Putting a {slice.Id} slice of bread in the toaster".Dump();

        _breads.Add(slice);

        await Task.Delay(200).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<Toast>> Toast()
    {
        "Start toasting...".Dump();

        await Task.Delay(1000).ConfigureAwait(false);

        "Toasts are ready.".Dump();

        return _breads.Select(bread => new Toast(bread)).ToList();
    }
}

