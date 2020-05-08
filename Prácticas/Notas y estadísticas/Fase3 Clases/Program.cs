using Fase3_Clases.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fase3_Clases
{
    class Program
    {
        /* Keyword for the user to indicate when to go back to Main Menu 
         * Also used to flag stop adding grades 
         */
        const string EndKeyword = "main";

        #region Menues

        /* Dictionaries containning the valid Menu Options
         * This way they are open for further menu option additions with no need of modifying any method*/
        static Dictionary<string, string> MainMenuOptions = new Dictionary<string, string>()
        {
            //{"m", "Main Menu"},
            {"a", "Manage Students"},
            {"s", "Statistics Menu"},
            {"x", "Exit Program"}
        };

        static Dictionary<string, string> StatsMenuOptions = new Dictionary<string, string>()
        {
            {"avg", "get the Average Student Grade"},
            {"min", "get the Lowest Student Grade"},
            {"max", "get the Highest Student Grade"},
            {EndKeyword, "Exit this Menu"}
        };

        static Dictionary<string, string> StudentsMenuOptions = new Dictionary<string, string>()
        {
            {"all", "get All the Students"},
            {"add", "Add a New Student"},
            {"edit", "Update a Student"},
            {"del", "Remove a Student"},
            {"show", "Get a Student data"},
            {"exams", "Get a Student Exams"},
            {"subj", "Get a Student Subjects"},
            {EndKeyword, "Exit this Menu"}
        };
        #endregion Menues

        ///* List to store the grades */
        //static List<double> GradesList = new List<double>();
        static void Main(string[] args)
        {
            /* Welcome and Main Menu options */
            Welcome();

            /* Get a valid Main Menu option */
            string option;
            bool validOption;

            option = GetMenuOption(MainMenuOptions, out validOption);
            while (!validOption)
            {
                ShowMainMenu();
                option = GetMenuOption(MainMenuOptions, out validOption);
            }

            /* Get submenu options */
            while (option != "x")
            {
                switch (option)
                {
                    case "m":
                        ShowMainMenu();
                        option = GetMenuOption(MainMenuOptions, out validOption);
                        while (!validOption)
                        {
                            ShowMainMenu();
                            option = GetMenuOption(MainMenuOptions, out validOption);
                        }
                        break;
                    case "a":
                        ShowStudentsMenu();
                        option = GetMenuOption(StudentsMenuOptions, out validOption);
                        while (!validOption)
                        {
                            ShowStudentsMenu();
                            option = GetMenuOption(StudentsMenuOptions, out validOption);
                        }
                        ManageStudents(option);
                        /* Keep CRUD Students or back to Main*/
                        if (option == EndKeyword)
                        {
                            option = "m";
                        }
                        else
                        {
                            option = "a";
                        }
                        //AddGrades();
                        break;
                    case "s":
                        if (GradesList.Count > 0)
                        {
                            ShowStatisticsMenu();
                            option = GetMenuOption(StatsMenuOptions, out validOption);
                            while (!validOption)
                            {
                                ShowStatisticsMenu();
                                option = GetMenuOption(StatsMenuOptions, out validOption);
                            }
                            GetStats(option);
                            /* Keep calculating Stats or back to Main*/
                            if (option == EndKeyword)
                            {
                                option = "m";
                            }
                            else
                            {
                                option = "s";
                            }
                        }
                        else
                        {
                            Console.WriteLine("No student has been added to the DB so far.");
                            Console.WriteLine("You will be taken to Main Menu where you can choose to Add Students to the DB");
                            option = "m";
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        static void Welcome()
        {
            Console.WriteLine("Welcome to the Students Management Program");
            ShowMainMenu();
        }
        static void ShowMainMenu()
        {
            Console.WriteLine("\n-- Main Menu Options --");
            ShowMenuOptions(MainMenuOptions);
        }
        static void ShowMenuOptions(Dictionary<string, string> aMenuOptions)
        {
            foreach (var kvp in aMenuOptions)
            {
                Console.WriteLine("Type \"{0}\" to {1}", kvp.Key, kvp.Value);
            }
        }
        static void ShowStatisticsMenu()
        {
            Console.WriteLine("\n --Statistics Menu-- ");
            ShowMenuOptions(StatsMenuOptions);
        }
        static void ShowStudentsMenu()
        {
            Console.WriteLine("\n-- Manage Student Menu Options --");
            ShowMenuOptions(StudentsMenuOptions);
        }
        static string GetMenuOption(Dictionary<string, string> aMenu, out bool isValid)
        {
            var selectedMenuOption = ReadMenuOption();
            isValid = IsValidMenuOption(selectedMenuOption, aMenu);
            if (!isValid)
            {
                Console.WriteLine("\n\"{0}\" is not a valid option", selectedMenuOption);
                Console.WriteLine("Please, select among the following options:");
            }
            return selectedMenuOption;
        }
        static string ReadMenuOption()
        {
            return Console.ReadLine();
        }
        static bool IsValidMenuOption(string aOption, Dictionary<string, string> aMenu)
        {
            /* First time Main Menu is showed it takes a null option as input */
            if (aOption == null)
            {
                return false;
            }
            else //When an actual option was typed
            {
                return aMenu.Keys.Contains(aOption);
            }
        }

        
        static string GetStudentDNI()
        {
            Console.WriteLine("Please, enter the Student DNI");
            return Console.ReadLine();
        }

        static string GetStudentName()
        {
            Console.WriteLine("Please, enter the Student Name");
            return Console.ReadLine();
        }

        static void ManageStudents(string aOption)
        {
            switch (aOption)
            {
                case EndKeyword:
                    break;
                case "all":
                    var gradesAvg = CalcGradesAvg(GradesList);
                    Console.WriteLine("The average grade is {0}", gradesAvg);
                    break;
                case "add":
                    var dni = GetValidDNI();
                    //add student
                    break;
                case "edit":
                    var gradesMax = CalcGradesMax(GradesList);
                    Console.WriteLine("The highest grade is {0}", gradesMax);
                    break;
                case "del":
                    var gradesMax = CalcGradesMax(GradesList);
                    Console.WriteLine("The highest grade is {0}", gradesMax);
                    break;
                case "exams":
                    var gradesMax = CalcGradesMax(GradesList);
                    Console.WriteLine("The highest grade is {0}", gradesMax);
                    break;
                case "subj":
                    var gradesMax = CalcGradesMax(GradesList);
                    Console.WriteLine("The highest grade is {0}", gradesMax);
                    break;
            default:
                    break;
            }
        }
        static void AddGrades()
        {
            /* Keep adding grades until user types the end keyword */
            bool isLastGrade = false;
            string inputGrade;

            while (!isLastGrade)
            {
                AskForAGrade(GradesList.Count + 1);
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
        }
        static void AskForAGrade(int aStudentNumber)
        {
            Console.WriteLine("\nEnter Student {0} grade: ", aStudentNumber);
        }
        static void AddStudentGrade(double aGrade)
        {
            GradesList.Add(aGrade);
        }
        static bool LastGrade(string aInput)
        {
            return aInput == EndKeyword;
        }
        static bool CheckGrade(string aGrade)
        {
            return double.TryParse(aGrade, out double result);
        }
        static string DotToComma(string aStringWithDot)
        {
            return aStringWithDot.Replace('.', ',');
        }
        static void GetStats(string aCalcOption)
        {
            switch (aCalcOption)
            {
                case EndKeyword:
                    break;
                case "avg":
                    var gradesAvg = CalcGradesAvg(GradesList);
                    Console.WriteLine("The average grade is {0}", gradesAvg);
                    break;
                case "min":
                    var gradesMin = CalcGradesMin(GradesList);
                    Console.WriteLine("The lowest grade is {0}", gradesMin);
                    break;
                case "max":
                    var gradesMax = CalcGradesMax(GradesList);
                    Console.WriteLine("The highest grade is {0}", gradesMax);
                    break;
                default:
                    break;
            }
        }
        static double CalcGradesAvg(List<double> aGradesList)
        {
            /* Use LINQ */
            return aGradesList.Average();
        }
        static double CalcGradesMin(List<double> aGradesList)
        {
            /* Use LINQ */
            return aGradesList.Min();
        }
        static double CalcGradesMax(List<double> aGradesList)
        {
            /* Use LINQ */
            return aGradesList.Max();
        }
    }
}
