using System;

namespace Fase4
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "Dayté Dayana";
            var firtsLastname = "Rodríguez";
            var secondLastname = "Martínez";
            var fullName = name + " " + firtsLastname + " " + secondLastname;

            var day = 16;
            var month = 1;
            var year = 1983;
            var birthDate = day + "/" + month + "/" + year;

            Console.WriteLine($"My name is {fullName}");
            Console.WriteLine($"I was born {birthDate}");

            if (IsLeap(year))
            {
                Console.WriteLine($"My birth year is leap");
            }
            else
            {
                Console.WriteLine($"My birth year is not leap");
            }
        }
        private static bool IsLeap(int aYear)
        {
            bool isLeap;
            int i;
            for (i = Constants.firstLeapYear; i <= aYear; i += Constants.newLeapYear)
            {
                
            }

            isLeap = aYear == i - Constants.newLeapYear;
            return isLeap;
        }
    }

    static class Constants
    {
        public const int firstLeapYear = 1948;
        public const int newLeapYear = 4;
    }
}
