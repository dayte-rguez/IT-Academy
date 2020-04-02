using System;
using System.Collections.Generic;
using System.Linq;

namespace Fase4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the array containing the characters of the name
            char[] nameArray = { 'D', 'a', 'y', 't', 'é' };

            //Create the list that contains the characters of the name
            var nameList = ArrayToList(nameArray);

            //Create a list with tha lastname
            var lastnameList = new List<char>();
            lastnameList.Add('R');
            lastnameList.Add('o');
            lastnameList.Add('d');
            lastnameList.Add('r');
            lastnameList.Add('í');
            lastnameList.Add('g');
            lastnameList.Add('u');
            lastnameList.Add('e');
            lastnameList.Add('z');

            //Show full name
            FullnameList(nameList, lastnameList);
        }
        private static void FullnameList(List<char> aNameList, List<char> aLastnameList)
        {
            aNameList.Add(' ');
            var fullnameList = aNameList.Concat(aLastnameList);
                        
            foreach (var item in fullnameList)
            {
                Console.WriteLine(item);
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
