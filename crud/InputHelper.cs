using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    public static class InputHelper
    {
        //int validáció
        public static int GetValidInt(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    return value;
                }

                Console.WriteLine("Hibás számformátum! Kérlek, egész számot adj meg.");
            }
        }
        // üres string validáció
        public static string GetNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Ez a mező nem lehet üres!");
            }
        }
    }
}
