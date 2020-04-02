using System;

namespace Fase1
{
    class Program
    {
        static void Main(string[] args)
        {
            string city1;
            string city2;
            string city3;
            string city4;
            string city5;
            string city6;

            Console.WriteLine("1st city name 1: ");
            city1 = Console.ReadLine();

            Console.WriteLine("2nd city name: ");
            city2 = Console.ReadLine();

            Console.WriteLine("3rd city name: ");
            city3 = Console.ReadLine();

            Console.WriteLine("4th city name: ");
            city4 = Console.ReadLine();

            Console.WriteLine("5th city name: ");
            city5 = Console.ReadLine();

            Console.WriteLine("6th city name: ");
            city6 = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"The cities are: ");
            Console.WriteLine($"{city1}");
            Console.WriteLine($"{city2}");
            Console.WriteLine($"{city3}");
            Console.WriteLine($"{city4}");
            Console.WriteLine($"{city5}");
            Console.WriteLine($"{city6}");
        }
    }
}
