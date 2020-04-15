using System;
using System.Linq;

namespace Fase4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create data source */
            string[] arrayNames = { "David", "Sergio", "Maria", "Laura", "Oscar", "Julia", "Oriol" };

            /* Create the queries */
            //var oNames = from name in arrayNames
            //             where name[0] == 'O'
            //             select name;

            //var sixCharNames = from name in arrayNames
            //                   where name.Length == 6
            //                   select name;

            //var namesDesc = from name in arrayNames
            //                orderby name descending
            //                select name;

            /* In method syntax */
            var oNames = arrayNames.Where(name => name[0] == 'O');
            var sixCharNames = arrayNames.Where(name => name.Length == 6);
            var namesDesc = arrayNames.OrderByDescending(name => name);

            /* Execute the query and show the data */
            Console.WriteLine("Original array with the names:");
            foreach (var name in arrayNames)
            {
                Console.Write("{0,1} ", name);
            }

            Console.WriteLine("\n\nArray with names starting with \"O\":");
            foreach (var oName in oNames)
            {
                Console.Write("{0,1} ", oName);
            }

            Console.WriteLine("\n\nArray with names of 6 letters:");
            foreach (var name in sixCharNames)
            {
                Console.Write("{0,1} ", name);
            }

            Console.WriteLine("\n\nArray with names sorted descending:");
            foreach (var name in namesDesc)
            {
                Console.Write("{0,1} ", name);
            }
        }
    }
}
