using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace crud
{
    //Json létrehozása
    internal class CreateJson
    {
        public void MakeJson() 
        {
            var prod = new List<Prod>
            {
                new Prod {ID = 1, Brand = "Dell", Tipus ="G15", Price = 199990},
                new Prod {ID = 2, Brand = "Asus", Tipus ="TUF", Price = 149990},
                new Prod {ID = 3, Brand = "HP", Tipus ="ZBook", Price = 79990},
                new Prod {ID = 4, Brand = "Lenovo", Tipus ="Gaming3", Price = 174990},
                new Prod {ID = 5, Brand = "Toshiba", Tipus = "Satellite", Price = 49990}
            };
            string jsonString = JsonSerializer.Serialize(prod, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("prod.json", jsonString);

           // Console.WriteLine(jsonString);
        }
    }

}
