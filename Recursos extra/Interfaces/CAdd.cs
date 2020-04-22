using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class CAdd : IOperation
    {
        public double Result {get; set;}
        public List<double> ResultsList { get; set; }

        #region Interface methods implementation
        public void Calculate(double aFirstOperator, double aSecondOperator)
        {
            Result = aFirstOperator + aSecondOperator;
            ResultsList.Add(Result);
        }

        public void Display()
        {
            Console.WriteLine("The result of the addition is {0}", Result);
        }
        #endregion Interface methods implementation

        #region Class methods
        public CAdd()
        {
            ResultsList = new List<double>();
        }
        public void DisplayAllResults()
        {
            foreach (var result in ResultsList)
            {
                Console.WriteLine(result);
            }
        }
        #endregion Class methods
    }
}
