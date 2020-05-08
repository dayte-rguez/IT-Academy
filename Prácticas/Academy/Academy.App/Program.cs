using Academy.Library.Context;
using Academy.Library.Models;
using System;
using System.Linq;

namespace Academy.App
{
    class Program
    {
        public static string CurrentOption { get; set; }
        static void Main(string[] args)
        {
            /* Welcome and Main Menu options */
            Welcome();
            while (true)
            {
                var option = Console.ReadKey().KeyChar;
                if (option == 'm')
                {
                    ClearCurrentConsoleLine();
                    if (CurrentOption != "m")
                    {
                        Console.WriteLine();
                        ShowMainMenu();
                    }
                }
                else if (option == 'a')
                {
                    ClearCurrentConsoleLine();
                    if (CurrentOption != "a")
                    {
                        Console.WriteLine();
                        ShowHandleStudentsMenu();
                    }
                }
                else
                {
                    Console.WriteLine("\nThe option \"{0}\" is invalid, please, try again", option);
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
            CurrentOption = "m";
            Console.WriteLine("-- Main Menu Options --");

            Console.WriteLine("m - to return to Main Menu");
            Console.WriteLine("a - to Manage Students");
            Console.WriteLine("n - to Add Students Grades");
            Console.WriteLine("c - to get Statistics");
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static void ShowStudentsMenu()
        {
            Console.WriteLine("-- Students Management Menu --");
            Console.WriteLine("a       - to Add a New Student");
            Console.WriteLine("e + DNI - to Edit a Student by its DNI");
            Console.WriteLine("n       - to get the Student Data");
            Console.WriteLine("n/e     - to get a Student Exams");
            Console.WriteLine("n/e     - to get a Student Subjects");
            Console.WriteLine("m       - to return to Main Menu");
        }
            static string GetNewDNI()
            {
                Console.WriteLine("Enter the Student DNI or type * to abort:");
                var dni = Console.ReadLine();

                if (dni != "*")
                {
                    var keepLoop = true;
                    while (keepLoop)
                    {
                        if (Student.DniIsValid(dni))
                        {
                            if (DBContext.StudentByDNI.ContainsKey(dni))
                            {
                                Console.WriteLine("A Student with that DNI is already in the DB");
                                Console.WriteLine("Please, enter a new DNI or type * to abort");
                                dni = Console.ReadLine();
                                keepLoop = dni != "*";
                            }
                            else
                            {
                                keepLoop = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid DNI format, please, try again or type * to abort");
                            dni = Console.ReadLine();
                            keepLoop = dni != "*";
                        }
                    }
                }
                return dni;
            }
        static string GetValidName()
        {
            Console.WriteLine("Enter the Student Name or type * to abort");
            var name = Console.ReadLine();

            while ((name != "*") && (!Student.NameIsValid(name)))
            {
                Console.WriteLine("Invalid name, please, try again");
                name = Console.ReadLine();
            }
            return name;
        }
        static bool IsDBMatchingDNI(string aDni)
        {
            return ((Student.DniIsValid(aDni)) && DBContext.StudentByDNI.ContainsKey(aDni));
        }
        static void ShowHandleStudentsMenu()
        {
            CurrentOption = "a";
            string option, name, dni;
            char pressedKey;

            while (true)
            {
                ShowStudentsMenu();
                /* Remove all whitespaces */
                option = String.Concat(Console.ReadLine().Where(o => !Char.IsWhiteSpace(o)));

                #region Back to Main Menu
                if (option == "m")
                {
                    ShowMainMenu();
                    break;
                }
                #endregion
                #region Add a New Student
                else if (option == "a")
                {
                    /* Get a valid new DNI or the keyword to break */
                    dni = GetNewDNI();
                    if (dni == "*")
                    {
                        ShowMainMenu();
                        break;
                    }
                    /* Get a valid Student name or the keyword to break */
                    name = GetValidName();
                    if (name == "*")
                    {
                        ShowMainMenu();
                        break;
                    }
                    /* Create the Student */
                    var student = new Student
                    {
                        Dni = dni,
                        Name = name
                    };

                    /* Save the Student data */
                    if (student.Save())
                    {
                        Console.WriteLine("The student {0} with DNI {1} was succesfully added\n", student.Name, student.Dni);
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, the student {0} with DNI {1} was not added\n", student.Name, student.Dni);
                    }
                }
                #endregion
                #region Edit Student
                else if (option[0] == 'e')
                {
                    /* Get an existing DNI or the keyword to break */
                    dni = option.Substring(2);
                    while (!(IsDBMatchingDNI(dni)) && (dni != "*"))
                    {
                        Console.WriteLine("No Student associated with DNI {0} in the DB", dni);
                        Console.WriteLine("Please, enter a valid DNI or type \"*\" to abort");
                        dni = Console.ReadLine();
                    }
                    if (dni == "*")
                    {
                        ShowMainMenu();
                        break;
                    }
                    /* Get the ID related to the DNI */
                    var id = DBContext.StudentByDNI[dni].Id;

                    #region Edit DNI
                    /* Offer to provide a new valid DNI, keep the current one, or exit the edition */
                    Console.WriteLine("Press any key to update the DNI or \"*\" to keep the current one");
                    pressedKey = Console.ReadKey().KeyChar;
                    ClearCurrentConsoleLine();
                    if (pressedKey != '*')
                    {

                        dni = GetNewDNI();
                        if (dni == "*")
                        {
                            ShowMainMenu();
                            break;
                        }
                    }
                    #endregion

                    #region Edit Name
                    /* Offer to provide a new valid Student name or the keyword to break */
                    Console.WriteLine("Press any key to update the Name or \"*\" to keep the current one");
                    pressedKey = Console.ReadKey().KeyChar;
                    ClearCurrentConsoleLine();
                    if (pressedKey != '*')
                    {
                        name = GetValidName();
                        if (name == "*")
                        {
                            ShowMainMenu();
                            break;
                        }
                    }
                    else
                    {
                        name = DBContext.Students[id].Name;
                    }
                    #endregion

                    /* Create the new data Student */
                    var student = new Student
                    {
                        Id = id,
                        Dni = dni,
                        Name = name
                    };
                    /* Save the Student data */
                    if (student.Save())
                    {
                        Console.WriteLine("The student was succesfully edited resulting the following data:");
                        Console.WriteLine("Name: {0}\nDNI: {1}", student.Name, student.Dni);
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, the student {0} with DNI {1} was not added\n", student.Name, student.Dni);
                    }
                }
                #endregion
                else
                {
                    Console.WriteLine("The option \"{0}\" is invalid, please, try again", option);
                }
            }
        }
    }
}
