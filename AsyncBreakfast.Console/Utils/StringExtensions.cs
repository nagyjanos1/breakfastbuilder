namespace AsyncBreakfast.Console.Utils
{
    public static class StringExtensions
    {
        public static void Dump(this string text)
        {
            System.Console.WriteLine($"{DateTime.Now} {text}");
        }
    }
}
