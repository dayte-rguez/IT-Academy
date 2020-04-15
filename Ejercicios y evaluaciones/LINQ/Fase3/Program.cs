using System;
using System.Linq;

namespace Fase3
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create data source */
            int[] arrayNum = { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };

            /* Create the queries and dump results to arrays*/
            //var greaterThanFive = (from num in arrayNum
            //                where num > 5
            //                select num).ToArray();
            //var lessThanFive = (from num in arrayNum
            //                      where num < 5
            //                      select num).ToArray();

            /* In method syntax */
            var greaterThanFive = arrayNum.Where(num => num > 5).ToArray();
            var lessThanFive = arrayNum.Where(num => num < 5).ToArray();

            /* Alternative distinct output */
            var distinctGreater = greaterThanFive.Distinct();
            var distinctLess = lessThanFive.Distinct();

            /* Show the arrays */
            Console.WriteLine("Original array of numbers: ");
            foreach (var number in arrayNum)
            {
                Console.Write("{0,1} ", number);
            }

            Console.WriteLine("\n\nArray of numbers > 5: ");
            foreach (var number in greaterThanFive)
            {
                Console.Write("{0,1} ", number);
            }

            Console.WriteLine("\n\nAlternative output: Array of distinct numbers > 5: ");
            foreach (var number in distinctGreater)
            {
                Console.Write("{0,1} ", number);
            }

            Console.WriteLine("\n\nAlternative output: Array of numbers < 5: ");
            foreach (var number in lessThanFive)
            {
                Console.Write("{0,1} ", number);
            }

            Console.WriteLine("\n\nArray of distinct numbers < 5: ");
            foreach (var number in distinctLess)
            {
                Console.Write("{0,1} ", number);
            }
        }
    }

}
