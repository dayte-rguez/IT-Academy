using System;

namespace Interfaces
{
    class Program
    {
        /* Understanding the use of Interface through a Calculator App:
         * 1.- What does a calculator do? Math operations
         * 2.- What's the semantic and behavior of maths operations? Calculate and Offer a result
         * e.g.: To add, substract. multiply, divide... a calculation must be done and a result must be shown
         * The abstract concepts to specify in the Interface (IOperation) would be Calculate and Display. 
         * Since both methods are specific and different to each particular math operation, they must be 
         * "described" in the classes (CAdd) that implement this Interface */
        static void Main(string[] args)
        {
            var math = "add";
            double firtsOperator;
            double secondOperator;

            /* Define a polymorphic variable through the use of the Interface 
             * so, var operation can act as "add" or "subs" conveniently*/
            IOperation operation;

            //To avoid use of non defined variable error
            operation = new CAdd();

            while(math != "stop")
            {
                Console.WriteLine("Enter add or subs");
                math = Console.ReadLine();
                Console.WriteLine("Enter first operator");
                firtsOperator = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter second operator");
                secondOperator = double.Parse(Console.ReadLine());

                /* Apply polymorphism */
                if (math == "add")
                {
                    operation = new CAdd();
                }
                else if (math == "subs")
                {
                    operation = new CSubs();
                }
                operation.Calculate(firtsOperator, secondOperator);
                operation.Display();

            }
        }
    }
}
