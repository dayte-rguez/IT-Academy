using System;

namespace Fase3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Show the leap years between 1948 and the birthyear
            var lastLeap = ShowLeaps();

            //Show if the birthyear is leap
            IsBirthyearLeap(lastLeap);
        }

        private static void IsBirthyearLeap(int aLastLeap)
        {
            var leapBirthYear = aLastLeap == Constants.birthYear;
            var isLeap = $"The birthyear {Constants.birthYear} is leap";
            var isNotLeap = $"The birthyear {Constants.birthYear} is not leap";

            if (leapBirthYear)
            {
                Console.WriteLine(isLeap);
            }
            else
            {
                Console.WriteLine(isNotLeap);
            }
        }

        private static int ShowLeaps()
        {
            int i;
            for (i = Constants.firstLeapYear; i <= Constants.birthYear; i += Constants.newLeapYear)
            {
                Console.WriteLine($"{i}");
            }

            return i - Constants.newLeapYear;
        }
    }

    static class Constants
    {
        public const int firstLeapYear = 1948;
        public const int newLeapYear = 4;
        public const int birthYear = 1983;
    }
}
