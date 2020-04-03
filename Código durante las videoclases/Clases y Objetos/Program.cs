using System;

namespace Clases_y_Objetos
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Structured programming

            var name = "Dayte"; 
            var year = 1983;
            var email = "a@a.com";

            ShowPersonalInfo(name, year, email);

            //Receiving vars as parameters
            static void ShowPersonalInfo(string aName, int aYear, string aMail)
            {
                Console.WriteLine($"Función estática (Receiving vars as " +
                    $"parameters): La persona con nombre {aName} que nació en " +
                    $"{aYear} y que tiene el email {aMail}\n");
            }

            //Receiving an object as parameter
            static void ShowObjectPersonInfo(Person aPerson)
            {
                Console.WriteLine($"Función estática (Receiving an object as " +
                    $"parameter): La persona con nombre {aPerson.Name} que nació " +
                    $"en {aPerson.Year} y que tiene el email {aPerson.Email}\n");
            }

            #endregion Structured programming

            #region OOP

            #region Creating an object 

            /* Option A (the most elegant): 
             * Create the object with the empty Constructor
             * and assign values to its Properties 
             */
            var dayteA = new Person
            {
                Name = name + "A",
                Year = year,
                Email = email
            };

            /* Option B: Create the object with the empty Constructor 
             * and once the object was created, assign values to its Properties             
             */
            var dayteB = new Person();
            dayteB.Name = name + "B";
            dayteB.Year = year;
            dayteB.Email = email;

            /* Option C (The less recommended): 
             * The object can be created by using the Constructor that takes 
             * the properties values as parameters.
             * In this example, data will be showed for the object dayteC
             * at the moment of its creation as it is the way it was defined
             * in the Constructor.
             */
            var dayteC = new Person(name + "C", year, email);            

            #endregion Creating an object 

            //Using Object methods
            dayteA.ShowClassPersonInfo();

            #endregion OOP

            /*Structured programming function: 
             * Pass object properties as parameters*/
            ShowPersonalInfo(dayteB.Name, dayteB.Year, dayteB.Email);

            /*Structured programming function: 
             * Pass object as parameter*/
            ShowObjectPersonInfo(dayteA);
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Email { get; set; }

        /* First task when creating a Class:
         * Create the Constructor, 
         * it must have the same name of the Class (shortcut "ctor").
         * C# allows to create more than one Constructor (overload)
         * By creating  2 Constructors we offer the possibility to create
         * a Person object either by:
         * - Most recommended way: Non defining its properties (empty Constructor)
         * and asking for them (or getting them somehow);
         * - Less recommended way: Getting the Object properties from the 
         * very beginning (passing the values as Constructor parameters)
         */

        /* Empty Constructor (the most recommended Constructor) */
        public Person()
        { 
        
        }
        /* Less recommended Constructor */
        public Person(string aName, int aYear, string aMail)
        {
            Name = aName;
            Year = aYear;
            Email = aMail;

            /* Since we have the data, this Constructor allows to manipulate it 
             * right away if we want, e.g. calling a method.
             */
            ShowClassPersonInfo();

            /* This is also acceptable, although no necessary in C#, however
             * when copying and pasting from C# to JS is useful, since it is 
             * the correct way in JS
            
                this.Name = aName;
                this.Year = aYear;
                thisEmail = aMail; 
            */
        }
        /* For all the methods belonging to the class Person: there is no need to 
         * reference an object "Person" as input parameter for them.
         * All the Properties and Methods within the class are accesible to 
         * anything inside the class.
         */
        public void ShowClassPersonInfo()
        {
            Console.WriteLine($"Método OOP: La persona con nombre {Name} " +
                $"que nació en {Year} y que tiene el email {Email}\n");
        }

        /* The easy way to paste in JS: include "this" to reference de Object
          
        public void ShowClassPersonInfo()
        {
            Console.WriteLine($"Método OOP: La persona con nombre {this.Name} que nació en {this.Year} y que tiene el email {this.Email}");
        } 

         */
    }
}
