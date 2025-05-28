using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace crud
{
    internal class CreateJson
    {
        public void MakeJson() 
        {
            var prod = new List<Prod>
            {
                new Prod {ID = 1, Brand = "Dell", Tipus ="G15"},
                new Prod {ID = 2, Brand = "Asus", Tipus ="TUF"},
                new Prod {ID = 3, Brand = "HP", Tipus ="ZBook"},
                new Prod {ID = 4, Brand = "Lenovo", Tipus ="Gaming3"}
            };
            string jsonString = JsonSerializer.Serialize(prod, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("prod.json", jsonString);

           // Console.WriteLine(jsonString);
        }
    }

    public class Prod
    {
        public int ID {  get; set; }
        public string Brand { get; set; }
        public string Tipus { get; set; }
    }
}
