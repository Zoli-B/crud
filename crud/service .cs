using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;


namespace crud
{
    public class Crud
    {
        public void Create()
        {
            Error error = new Error(); 
            error.CheckJsonExist();
            
            string json = File.ReadAllText("prod.json");
            List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json);

            int ID = lista.Any() ? lista.Max(p => p.ID) + 1 : 1;
            string Brand = InputHelper.GetNonEmptyString("Add meg a termék új Márkáját:");
            string Tipus = InputHelper.GetNonEmptyString("Add meg a termék új Modelljét:");
            int Price = InputHelper.GetValidInt("Add meg a termék árát");


            var ujProd = new Prod
            {
                ID = ID,
                Brand = Brand,
                Tipus = Tipus,
                Price = Price
            };


            if (lista.Any(p => p.ID == ID))
            {
                Console.WriteLine($"Ez az ID ({ID}) már létezik");
                Create(); 
                return;  
            }

           lista.Add(ujProd);
           string ujJson = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
           File.WriteAllText("prod.json", ujJson);
            
                
        }

        public void Read()
        {
            Error error = new Error();
            error.CheckJsonExist();

            string json = File.ReadAllText("prod.json");
            List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json);

            foreach (var prod in lista)
            {
                Console.WriteLine($"ID: {prod.ID} - Brand: {prod.Brand} - Tipus: {prod.Tipus}");
            }

        }
        public void Update()
        {
            Error error = new Error();
            error.CheckJsonExist();

            string json = File.ReadAllText("prod.json");
            List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json);

            int ID = InputHelper.GetValidInt("Add meg az új ID-t");

            var talalat = lista.Find(prod => prod.ID == ID);

            if (talalat != null)
            {
                Console.WriteLine($"ID: {talalat.ID} - Brand: {talalat.Brand} - Tipus: {talalat.Tipus} - Ár {talalat.Price}");
                string ujBrand = InputHelper.GetNonEmptyString("Add meg a termék új Márkáját:");
                string ujTipus = InputHelper.GetNonEmptyString("Add meg a termék új Modelljét:");
                int ujPrice = InputHelper.GetValidInt("Add meg a termék új árát");


                talalat.Brand = ujBrand;
                talalat.Tipus = ujTipus;
                talalat.Price = ujPrice;

                string ujJson = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("prod.json", ujJson);
            
        }
            else
            {
                Console.WriteLine($"Nincs ilyen ID ({ID}), próbáld újra.");
                Update();
            }

        }

        public void Delete() 
        {
            Error error = new Error();
            error.CheckJsonExist();

            string json = File.ReadAllText("prod.json");
            List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json);

            int deleteID = InputHelper.GetValidInt("Add meg az új ID-t");

            var talalat = lista.Find(prod => prod.ID == deleteID);

            if (talalat != null)
            {
                lista.Remove(talalat);
                string ujJson = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("prod.json", ujJson);
            }
            else 
            {
                Console.WriteLine($"Nincs ilyen ID ({deleteID}), próbáld újra.");
                Delete();
            }

        }
    }
}
