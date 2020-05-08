using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fase3_Clases.Lib.Models
{
    class Menu
    {
        public Dictionary<string, string> MenuOptions { get; set; } = new Dictionary<string, string>();

        public void ShowMenuOptions()
        {
            foreach (var kvp in MenuOptions)
            {
                Console.WriteLine("Type \"{0}\" to {1}", kvp.Key, kvp.Value);
            }
        }
        public bool IsValidMenuOption(string aOption)
        {
            return MenuOptions.Keys.Contains(aOption);
        }
        public string GetMenuOption(out bool isValid)
        {
            var selectedMenuOption = Console.ReadLine();

            if (!IsValidMenuOption(selectedMenuOption))
            {
                Console.WriteLine("\n\"{0}\" is not a valid option", selectedMenuOption);
                Console.WriteLine("Please, select among the following options:");
            }
            return selectedMenuOption;
        }
    }
}
