using System;

namespace Fase3
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
            var message = "Sorted cities:";
            ShowSortedCities(arrayCities, message);

            //Replace 'a' for '4' in every ciy
            var replacedCities = ReplaceCities(arrayCities);
            message = "Replaced sorted cities:";
            ShowSortedCities(replacedCities, message);

        }
        private static string[] ReplaceCities(string[] aArrayCities)
        {
            //Get the lenght of the original array to create the modified new one
            var size = aArrayCities.Length;
            string[] replacedArray = new string[size];
            string replacedCity;

            for (int i = 0; i < size; i++)
            {
                replacedCity = aArrayCities[i].Replace('a', '4');
                replacedArray[i] = replacedCity;
            }
            return replacedArray;
        }

        private static void ShowSortedCities(string[] aArrayCities, string aMessage)
        {
            Console.WriteLine();
            Console.WriteLine(aMessage);
            foreach (var item in aArrayCities)
            {
                Console.WriteLine(item);
            }
        }
    }
}
