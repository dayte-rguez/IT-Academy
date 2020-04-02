using System;
using System.Collections.Generic;

namespace Fase3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the array containing the characters of the name
            char[] nameArray = { 'D', 'a', 'y', 't', 'é' };

            //Create the list that contains the characters of the name
            var nameList = ArrayToList(nameArray);

            //Create a dictionary where key = name char, value = char frequency in the name
            NameDictionary(nameList);
        }

        private static void NameDictionary(List<char> aList)
        {
            char key; //contains the name char
            int value; //contains how many times it appears in the name
            var nameDictionary = new Dictionary<char, int>();

            for (int i = 0; i < aList.Count; i++)
            {
                key = aList[i];
                value = 1;
                for (int j = i + 1; j < aList.Count; j++)
                {
                    if (aList[j] == key)
                    {
                        value++;
                        aList.RemoveAt(j);
                        j--;
                    }
                }
                nameDictionary.Add(key, value);
            }
            foreach (var kvp in nameDictionary)
            {
                Console.WriteLine($"{kvp.Key} appears {kvp.Value} time(s)");
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
