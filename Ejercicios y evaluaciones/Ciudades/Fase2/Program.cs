using System;

namespace Fase2
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

            //Create an array containing the cities
            string[] arrayCities = { city1, city2, city3, city4, city5, city6 };

            //Show the cities alphabetically sorted
            Array.Sort(arrayCities);
            Console.WriteLine();
            Console.WriteLine("Sorted cities:");
            foreach (var item in arrayCities)
            {
                Console.WriteLine(item);
            }

        }
    }
}
