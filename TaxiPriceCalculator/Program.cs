﻿using System;

namespace TaxiPriceCalculator
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello Taxi Price Calculator! Your cost would be: {new TaxiPriceCalculator().Cost()}");
        }
    }
}