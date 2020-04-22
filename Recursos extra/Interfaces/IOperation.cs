using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    interface IOperation
    {
        void Calculate(double aFirstOperator, double aSecondOperator);
        void Display();
    }
}
