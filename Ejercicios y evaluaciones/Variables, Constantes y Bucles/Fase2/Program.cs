using System;

namespace Fase2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Calculate how many leap years are between the created constant 
              and my birthyear.
              Operator / only returns the int part of the division*/
            var birthYear = 1983;
            var numLeapYear = (birthYear - Constants.firstLeapYear) / Constants.newLeapYear;
            Console.WriteLine($"There are {numLeapYear} leap years between {Constants.firstLeapYear} and {birthYear}");
        }
    }

    static class Constants
    {
        //Create a constant containing the leap year 1948
        public const int firstLeapYear = 1948;

        //Create a constant with the period needed for a new leap year
        public const int newLeapYear = 4;
    }
}
