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
            Console.WriteLine("To finish the program, press \"f\"");

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
                else if (option == 'f')
                {
                    keepDoing = false;
                }
                else
                {
                    Console.WriteLine("\nPlease, enter a valid option");
                    ShowMainMenu();
                }
            }
        }
        static void ShowStudentsMenu()
        {
            /*Console.WriteLine("To Update a Student, type \"edit\"");
            Console.WriteLine("To Delete a Student, type \"del\"");
            Console.WriteLine("To return to the Main Menu, type \"m\"");*/

            var keepDoing = true;
            while (keepDoing)
            {
                ShowStudentsMenuOptions();
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
                        Console.WriteLine("\nPlease, type a valid option");
                        break;
                }
            }
            ShowMainMenu();
        }

        private static void ShowStudentsMenuOptions()
        {
            Console.WriteLine("\n--Students Menu--");

            Console.WriteLine("To list All Students, type \"all\"");
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
            Console.WriteLine("To finish the program, press \"f\"");
        }

        private static string ShowStudentsUpdateMenu()
        {
            var result = "";

            while (result != "dni" && result != "name" && result != "cancel")
            {
                Console.WriteLine("To update the DNI, type \"dni\"");
                Console.WriteLine("To update the name, type \"name\"");
                Console.WriteLine("To return to the previous menu, type \"cancel\"");
                result = Console.ReadLine();
                if (result != "dni" && result != "name" && result != "cancel")
                {
                    Console.WriteLine("\nPlease, enter a valid option\n");
                }
            }
            return result;
        }
        static void ShowAllStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("\n The list of students is empty");
            }
            else
            {
                Console.WriteLine("\nList of all students:");
                /* Key = DNI; Value = Student Object */
                foreach (var kvp in Students)
                {
                    Console.WriteLine($"{kvp.Value.Dni} {kvp.Value.Name}");
                }
                Console.WriteLine();
            }
        }

        /* Validate that the input is either a DNI with a proper format (9 chars)
         * or the keyword "cancel" */
        static string ValidateDNI(string aDNI)
        {
            bool wrongDNI;
            if (aDNI != "cancel")
            {
                wrongDNI = aDNI.Length != 9;
                while (wrongDNI)
                {
                    Console.WriteLine("DNI format incorrect, please, try again " +
                        "or type \"cancel\" to abort");
                    aDNI = Console.ReadLine();
                    if (aDNI != "cancel")
                    {
                        wrongDNI = aDNI.Length != 9;
                    }
                    else
                    {
                        return aDNI;
                    }
                }
            }
            return aDNI;
        }

        static string ValidateName(string aName)
        {
            bool wrongName;
            if (aName != "cancel")
            {
                /* Make sure name is not empty */
                wrongName = aName.Trim().Length == 0;
                while (wrongName)
                {
                    Console.WriteLine("Name can not be empty, please, try again " +
                        "or type \"cancel\" to abort");
                    aName = Console.ReadLine();
                    if (aName != "cancel")
                    {
                        wrongName = aName.Trim().Length == 0;
                    }
                    else
                    {
                        return aName;
                    }
                }
            }
            return aName;
        }

        private static void AddNewStudent()
        {
            Console.WriteLine("Please, enter the DNI of the Student to be added " +
                "or type \"cancel\" to interrupt");
            var keepDoing = true;
            while (keepDoing)
            {
                /* Check DNI format and offer to abort if needed*/
                var dni = ValidateDNI(Console.ReadLine());

                if (dni == "cancel")
                {
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
                        }
                        keepDoing = false;
                        break;
                    }
                }
            }
        }

        private static void UpdateStudentField(Student aStudent, string aField)
        {
            string newValue;

            switch (aField)
            {
                case "dni":
                    Console.WriteLine("Please, enter the new DNI");
                    newValue = ValidateDNI(Console.ReadLine());
                    if (newValue != "cancel")
                    {
                        /* Remove old entry from the dictionary and add the new one */
                        Students.Remove(aStudent.Dni);
                        aStudent.Dni = newValue;
                        Students.Add(aStudent.Dni, aStudent);
                        Console.WriteLine($"Student DNI succesfully updated");
                    }
                    break;
                case "name":
                    Console.WriteLine("Please, enter the new name");
                    newValue = ValidateName(Console.ReadLine());
                    if (newValue != "cancel")
                    {
                        aStudent.Name = newValue;
                        Console.WriteLine($"Student Name succesfully updated");
                    }
                    break;
                case "cancel":
                    break;
                default:
                    Console.WriteLine("Please, type a valid option\n");
                    break;
            }
        }

        static void UpdateStudent()
        {
            /* Check if there is at least one student available to update */
            if (Students.Count > 0)
            {
                /* Get DNI and check format; offer to abort if needed*/
                Console.WriteLine("Please, enter the DNI of the Student to be " +
                        "updated or type \"cancel\" to interrupt");
                var dni = ValidateDNI(Console.ReadLine());

                if (Students.ContainsKey(dni))
                {
                    /* Get the student and show its data*/
                    var student = Students[dni];
                    Console.WriteLine("Current Student data:");
                    Console.WriteLine($"DNI: {student.Dni} Name: {student.Name}\n");

                    /* Get and validate the field to be updated */
                    var fieldToUpdate = ShowStudentsUpdateMenu();

                    /* Update the student (unless cancel selected) */
                    UpdateStudentField(student, fieldToUpdate);
                }
                else if (dni != "cancel") //Unknown DNI
                {
                    Console.WriteLine($"DNI {dni} not in the DataBase, please " +
                        $"add the Student before");
                }
            }
            else
            {
                Console.WriteLine("\nNothing to edit: The list of students is empty");
            }
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
