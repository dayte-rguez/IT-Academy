using Clases_y_Objetos.Lib.Models;
using System;
using System.Collections.Generic;

namespace Clases_y_Objetos
{
    /* *****************************************************************
     *                          Summary                                *
     * *****************************************************************
     * The aim of this practice is to use different classes to define: 
     * - Students
     * - Subjects
     * - Exams
     * and to add menu options to handle them 
     * *****************************************************************
     * Things that will be created following the teacher example:
     * - Entities (the classes that define the domain -functionality- of the program)
     * - The menu option to add a student
     * *****************************************************************
     * My goal:
     * To complete the rest of the CRUD functionalities:
     * Create, Read, Update, Destroy
     */
    class Program
    {
        /* Manage the students data using a dictionary where 
         * key = DNI, value = student 
         */
        public static Dictionary<string, Student> Students = new Dictionary<string, Student>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Students Management Program");
            Console.WriteLine("To manage Students, press \"a\"");
            Console.WriteLine("To get Statistics, press \"e\"");

            var keepDoing = true;
            while (keepDoing)
            {
                /* Get the Unicode character of the pressed key */
                var option = Console.ReadKey().KeyChar;
                if (option == 'a')
                {
                    ShowStudentsMenu();
                }
                else if (option == 'e')
                {
                    ShowStatsMenu();
                }
            }
        }
        static void ShowStudentsMenu()
        {
            ShowStudentsMenuOptions();

            /*Console.WriteLine("To list All the Students, type \"all\"");
            Console.WriteLine("To Add a new Student, type \"add\"");
            Console.WriteLine("To Update a Student, type \"edit\"");
            Console.WriteLine("To Delete a Student, type \"del\"");
            Console.WriteLine("To return to the Main Menu, type \"m\"");*/

            var keepDoing = true;
            while (keepDoing)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "all":
                        ShowAllStudents();
                        break;
                    case "add":
                        AddNewStudent();
                        break;
                    case "edit":
                        UpdateStudent();
                        break;
                    case "m":
                        keepDoing = false;
                        break;
                    default:
                        //AddMark(text);
                        break;
                }
            }
            ShowMainMenu();
        }

        private static void ShowStudentsMenuOptions()
        {
            Console.WriteLine("\n--Students Menu--");

            Console.WriteLine("To list All the Students, type \"all\"");
            Console.WriteLine("To Add a new Student, type \"add\"");
            Console.WriteLine("To Update a Student, type \"edit\"");
            Console.WriteLine("To Delete a Student, type \"del\"");
            Console.WriteLine("To return to the Main Menu, type \"m\"");
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("\n--Main Menu--");
            Console.WriteLine("To manage Students, press \"a\"");
            Console.WriteLine("To get Statistics, press \"e\"");
        }
        static void ShowAllStudents()
        {
            /* Key = DNI; Value = Student Object */
            foreach (var kvp in Students)
            {
                Console.WriteLine($"{kvp.Value.Dni} {kvp.Value.Name}");
            }
        }

        static string CheckDNI(string aDNI)
        {
            var end = (aDNI == "cancel");
            bool wrongDNI;
            if (!end)
            {
                wrongDNI = ((string.IsNullOrEmpty(aDNI)) || (aDNI.Length != 9));
                while (wrongDNI)
                {
                    Console.WriteLine("DNI format incorrect, please, try again " +
                        "or type \"cancel\" to abort");
                    aDNI = Console.ReadLine();
                    end = (aDNI == "cancel");
                    if (!end)
                    {
                        wrongDNI = string.IsNullOrEmpty(aDNI) || (aDNI.Length != 9);
                    }
                    else
                    {
                        return aDNI;
                    }
                }
            }
            return aDNI;
        }

        static void AddNewStudent()
        {
            Console.WriteLine("Please, enter the DNI or type \"cancel\" to interrupt");
            var keepDoing = true;
            while (keepDoing)
            {
                /* Check DNI format and offer to abort if needed*/
                var dni = CheckDNI(Console.ReadLine());

                if (dni == "cancel")
                {
                    ShowStudentsMenuOptions();
                    break;
                }

                else if (Students.ContainsKey(dni))
                {
                    Console.WriteLine($"DNI {dni} already in the DataBase");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Please, enter the Student Name or type \"cancel\" to interrupt");
                        var name = Console.ReadLine();

                        if (name == "cancel")
                        {
                            keepDoing = false;
                            break;
                        }

                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("The Student Name can not be empty");
                        }
                        else
                        {
                            var student = new Student
                            {
                                Id = new Guid(), // Inherited from class Entity
                                Dni = dni,
                                Name = name
                            };
                            Students.Add(dni, student);
                            Console.WriteLine("Student successfully added");
                            ShowStudentsMenuOptions();
                        }
                        keepDoing = false;
                        break;
                    }
                }
            }
        }

        static void UpdateStudent()
        {

        }

        static void AddMark(string aText)
        {
            var mark = 0.0;

            if (double.TryParse(aText, out mark))
            {
                //Marks.Add(mark);
                Console.WriteLine("Succesfully Added Mark. " +
                    "\nYou can Add another Mark, " +
                    "press \"all\" to list All the Marks" +
                    "or press \"m\" to return to the Main Menu");
            }
            else
            {
                Console.WriteLine("Your input does not match with a Mark Format  " +
                    "please, try again.");
            }
        }

        static void ShowStatsMenu()
        {
            Console.WriteLine("\n--Statistics Menu--");
            Console.WriteLine("To check the Average Mark, type \"avg\"");
            Console.WriteLine("To check the Highest Mark, type \"max\"");
            Console.WriteLine("To check the Lowest Mark, type \"min\"");
            Console.WriteLine("To return to the Main Menu, type \"m\"");

            var keepDoing = true;
            while (keepDoing)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "avg":
                        ShowAverage();
                        break;
                    case "max":
                        ShowMaximum();
                        break;
                    case "min":
                        ShowMinimum();
                        break;
                    case "m":
                        keepDoing = false;
                        break;
                    default:
                        Console.WriteLine("Please, type a valid option");
                        break;
                }
            }
            ShowMainMenu();
        }

        static void ShowAverage()
        {
            //var suma = 0.0;

            //for (int i = 0; i < Marks.Count; i++)
            //{
            //    suma += Marks[i];
            //}

            //var average = suma / Marks.Count;
            //Console.WriteLine("The exams avg is {0}", average);
        }

        static void ShowMaximum()
        {
            //var max = 0.0;

            //for (int i = 0; i < Marks.Count; i++)
            //{
            //    if (Marks[i] > max)
            //    {
            //        max = Marks[i];
            //    }
            //    Console.WriteLine("The maximum mark is {0}", max);
            //}
        }

        static void ShowMinimum()
        {
        //    /* Same as below. Here using the ternary operator (?) */
        //    var min = Marks.Count == 0 ? 0.0 : Marks[0];

        //    /*var min = 0.0;

        //    if (Marks.Count == 0)
        //    {
        //        min = 0.0;
        //    }
        //    else
        //    {
        //        min = Marks[i];
        //    }*/

        //    for (int i = 0; i < Marks.Count; i++)
        //    {
        //        if (Marks[i] < min)
        //        {
        //            min = Marks[i];
        //        }
        //        Console.WriteLine("The minimum mark is {0}", min);
        //    }
        }
    }
}
