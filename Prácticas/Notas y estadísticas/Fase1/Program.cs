using System;
using System.Collections.Generic;
using System.Linq;

namespace Fase1
{
    class Program
    {
        /* Keyword for the user to indicate when to stop adding grades to the list*/
        static string endKeyword = "last";

        /* Var to check whether the user input is the previous keword*/
        static bool isLastGrade = false;

        /* List to store the grades */
        static List<double> gradesList = new List<double>();

        /* Var to hold the grades average */
        static double gradesAvg;
        static void Main(string[] args)
        {
            string inputGrade;
            /* Welcome and rules */
            MainMenu();

            /* Keep adding grades until user types "last" */
            while (!isLastGrade)
            {
                AskForAGrade(gradesList.Count + 1);
                inputGrade = Console.ReadLine();
                isLastGrade = LastGrade(inputGrade);
                if (!isLastGrade)
                {
                    /* Check grade is a valid number*/
                    if (CheckGrade(inputGrade))
                    {
                        inputGrade = DotToComma(inputGrade);
                        /* Add grade to Student*/
                        AddStudentGrade(double.Parse(inputGrade));
                    }
                    else
                    {
                        /* Start over */
                        Console.WriteLine("{0} is not a valid grade", inputGrade);
                    }
                }                 
            }
            /* Calculate Avg of grades */
            gradesAvg = CalcGradesAvg(gradesList);
            ShowGradesAvg(gradesAvg);
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to the Students Management Program");
            Console.WriteLine("To finish the program, type \"last\"");
        }

        static void AskForAGrade(int aStudentNumber)
        {
            Console.WriteLine("Enter Student {0} grade: ", aStudentNumber);
        }

        static void AddStudentGrade(double aGrade)
        {
            gradesList.Add(aGrade);
        }

        static bool LastGrade(string aInput)
        {
            return aInput == endKeyword;
        }
        static bool CheckGrade(string aGrade)
        {
            return double.TryParse(aGrade, out double result);
        }

        static string DotToComma(string aStringWithDot)
        {
            return aStringWithDot.Replace('.', ',');
        }

        static double CalcGradesAvg(List<double> aGradesList)
        {
            /* Use LINQ */
            return aGradesList.Average();
        }

        static void ShowGradesAvg(double aGradesAvg)
        {
            Console.WriteLine("The average grade is {0}", aGradesAvg);
        }
    }
}
