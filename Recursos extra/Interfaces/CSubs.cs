using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class CSubs : IOperation
    {
        public double Result { get; set; }
        public void Calculate(double aFirstOperator, double aSecondOperator)
        {
            Result = aFirstOperator - aSecondOperator;
        }

        public void Display()
        {
            Console.WriteLine("The result of the substraction is {0}", Result);
        }
    }
}
