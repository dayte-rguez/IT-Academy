using System;
using System.Linq;

namespace Fase2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create data source */
            int[] arrayNum = { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };

            /* Create the queries */
            var average = arrayNum.Average();
            var min = arrayNum.Min();
            var max = arrayNum.Max();

            /* Execute the queries */
            Console.Write("The average of the array is {0}, the minimum is {1} and the maximun {2}", average, min, max);
        }
    }
}
