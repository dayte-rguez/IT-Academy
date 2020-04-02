using System;

namespace Fase1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the array containing the characters of the name
            char[] nameArray = { 'D', 'a', 'y', 't', 'é' };

            ShowArray(nameArray);
        }

        private static void ShowArray(char[] aArray)
        {
            for (int i = 0; i < aArray.Length; i++)
            {
                Console.WriteLine(aArray[i]);
            }
        }
    }
}
