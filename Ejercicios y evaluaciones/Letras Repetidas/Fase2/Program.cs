using System;
using System.Collections.Generic;

namespace Fase1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the array containing the characters of the name
            char[] nameArray = { 'D', 'a', 'y', 't', 'é' };

            //Create the list that contains the characters of the name
            var nameList = ArrayToList(nameArray);

            NameAnalysis(nameList);
        }

        private static void NameAnalysis(List<char> aList)
        {
            foreach (var item in aList)
            {
                switch (item)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'á':
                    case 'é':
                    case 'í':
                    case 'ó':
                    case 'ú':
                    case 'Á':
                    case 'É':
                    case 'Í':
                    case 'Ó':
                    case 'Ú':
                        Console.WriteLine($"{item} is a vowel");
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        Console.WriteLine($"People's names do not contain numbers");
                        break;
                    default:
                        Console.WriteLine($"{item} is a consonant");
                        break;
                }
            }
        }

        private static List<char> ArrayToList(char[] aArray)
        {
            var listArray = new List<char>();

            for (int i = 0; i < aArray.Length; i++)
            {
                listArray.Add(aArray[i]);
            }
            return listArray;
        }
    }
}

