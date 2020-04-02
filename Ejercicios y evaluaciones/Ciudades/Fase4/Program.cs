using System;

namespace Fase4
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

            //Create an array for each city
            var arrayCiti1 = ArrayCity(city1);
            var arrayCiti2 = ArrayCity(city2);
            var arrayCiti3 = ArrayCity(city3);
            var arrayCiti4 = ArrayCity(city4);
            var arrayCiti5 = ArrayCity(city5);
            var arrayCiti6 = ArrayCity(city6);

            //Invert each array and show it
            var invertedCity1 = InvertedArray(arrayCiti1);
            ShowInvertedCities(invertedCity1, city1);

            var invertedCity2 = InvertedArray(arrayCiti2);
            ShowInvertedCities(invertedCity2, city2);

            var invertedCity3 = InvertedArray(arrayCiti3);
            ShowInvertedCities(invertedCity3, city3);

            var invertedCity4 = InvertedArray(arrayCiti4);
            ShowInvertedCities(invertedCity4, city4);

            var invertedCity5 = InvertedArray(arrayCiti5);
            ShowInvertedCities(invertedCity5, city5);

            var invertedCity6 = InvertedArray(arrayCiti6);
            ShowInvertedCities(invertedCity6, city6);
        }

        private static void ShowInvertedCities(char[] aInvertedCity, string aMessage)
        {
            Console.WriteLine();
            Console.WriteLine(aMessage);
            foreach (var item in aInvertedCity)
            {
                Console.WriteLine(item);
            }
        }

        private static char[] InvertedArray(char[] aArray) 
        {
            var size = aArray.Length;
            var invertedArray = new char[size];
            size--;

            for (int i = size; i >= 0; i--)
            {
                invertedArray[size - i] = aArray[i];
            }
            return invertedArray; 
        }

        private static char[] ArrayCity(string aCity)
        {
            var size = aCity.Length;
            var arrayCity = new char[size];

            for (int i = 0; i < size; i++)
            {
                arrayCity[i] = aCity[i];
            }
            return arrayCity;
        }
    }
}
