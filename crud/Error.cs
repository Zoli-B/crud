using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{

    internal class Error
    {
        public void CheckJsonExist()
        {
            if (!File.Exists("prod.json"))
            {
                Console.WriteLine("A fájl nem létezik, létrehozok egy új listát.");
                CreateJson createJson = new CreateJson();
                createJson.MakeJson();
            }
        }


    }

    public static class InputHelper
    {
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
