using crud;
using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                if (!System.IO.File.Exists("prod.json"))
                {
                    var emptyList = new List<Prod>();
                    string emptyJson = JsonSerializer.Serialize(emptyList, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText("prod.json", emptyJson);
                }

                string json = System.IO.File.ReadAllText("prod.json");
                List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json) ?? new List<Prod>();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Prod prod)
        {
            try
            {
                //json ellenörzés
                if (!System.IO.File.Exists("prod.json"))
                {
                    var emptyList = new List<Prod>();
                    string emptyJson = JsonSerializer.Serialize(emptyList, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText("prod.json", emptyJson);
                }
                // json beolvasása
                string json = System.IO.File.ReadAllText("prod.json");
                List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json) ?? new List<Prod>();

                //automatikus ID
                int newID = lista.Any() ? lista.Max(p => p.ID) + 1 : 1;
                prod.ID = newID;

                //Listához adás
                lista.Add(prod);
                string ujJson = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText("prod.json", ujJson);

                return CreatedAtAction(nameof(GetAll), new { id = prod.ID }, prod);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Prod updatedProd)
        {
            try
            {
                if (!System.IO.File.Exists("prod.json"))
                {
                    var emptyList = new List<Prod>();
                    string emptyJson = JsonSerializer.Serialize(emptyList, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText("prod.json", emptyJson);
                }
                string json = System.IO.File.ReadAllText("prod.json");
                List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json) ?? new List<Prod>();

                var talalat = lista.Find(p => p.ID == id);

                if (talalat != null)
                {
                    talalat.Brand = updatedProd.Brand;
                    talalat.Tipus = updatedProd.Tipus;
                    talalat.Price = updatedProd.Price;

                    string ujJson = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText("prod.json", ujJson);
                }
                else 
                {
                    return NotFound($"Nincs ilyen ID: {id}");
                }
                return Ok(talalat);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!System.IO.File.Exists("prod.json"))
                {
                    var emptyList = new List<Prod>();
                    string emptyJson = JsonSerializer.Serialize(emptyList, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText("prod.json", emptyJson);
                }

                string json = System.IO.File.ReadAllText("prod.json");
                List<Prod> lista = JsonSerializer.Deserialize<List<Prod>>(json) ?? new List<Prod>();

                var talalat = lista.Find(p => p.ID == id);

                if (talalat != null) 
                {
                    lista.Remove(talalat);
                    string ujJson = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText("prod.json", ujJson);
                }
                else
                {
                    return NotFound($"Nincs ilyen ID: {id}");
                }
                return Ok(talalat);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
        }
    }
}
