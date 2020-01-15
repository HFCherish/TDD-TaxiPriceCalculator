using System;
using System.Linq;

namespace TaxiPriceCalculator
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello Taxi Price Calculator! Your cost would be: {new TaxiPriceCalculator().Cost(Double.Parse(args[0]), args.ToList().GetRange(1, args.Length-1).Select(x =>Double.Parse(x)).ToArray())}");
        }
    }
}