namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Password p = new Password();
            p.ContainsSymbols = true;
            Console.WriteLine(p.generate(13));
        }
    }
}