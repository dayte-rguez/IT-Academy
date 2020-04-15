using System;
using System.Linq;

namespace Ejercicio_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create data source */
            int[] arrayNum = { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };

            /* Create the query */
            var arrayEven = from num in arrayNum
                            where (num % 2) == 0
                            select num;

            /* Execute the query */
            foreach (var evenNum in arrayEven)
            {
                /* Shows each number like a column separated by a space*/
                Console.Write("{0,2}", evenNum);
            }
        }
    }
}
