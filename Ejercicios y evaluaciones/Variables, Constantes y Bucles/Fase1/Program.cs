using System;

namespace Fase1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create 3 string variables for name and lastnames
            var name = "Dayté Dayana";
            var firtsLastname = "Rodríguez";
            var secondLastname = "Martínez";

            //Create 3 int variables with the birthdate
            var day = 16;
            var month = 1;
            var year = 1983;

            //Show the 3 strings concatenated
            Console.WriteLine($"{firtsLastname} {secondLastname}, {name}");

            //Show the 3 int concatenated
            Console.WriteLine($"{day}/{month}/{year}");
        }
    }
}
