using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DbController : BaseApiController
    {
        private readonly DataContext _db;

    //the framework handles this
    public DbController(DataContext db)
    {
        _db = db;
    }

        [HttpPost("dodajWynagrodzenie")]
        public async Task<ActionResult<WynagrodzenieE>> dodajWynagrodzenie(WynagrodzenieE wyn){

           

            var wynN = new WynagrodzenieE{
                Kod = wyn.Kod,
                Nazwa = wyn.Nazwa,
                Rok = wyn.Rok,
                Wartosc = wyn.Wartosc

            };
            _db.Wynagrodzenia.Add(wynN);
            await _db.SaveChangesAsync();

            return new WynagrodzenieE{
               
                Kod = wynN.Kod,
                Nazwa = wynN.Nazwa,
                Rok = wynN.Rok,
                Wartosc = wynN.Wartosc

            };

        }

        [HttpGet("dodajAllWynagrodzenia")]
        public async void dodajAllWynagrodzenia(){

         
             List<WynagrodzenieE> wynagrodzenia = new List<WynagrodzenieE>();
           
            using (StreamReader r = new StreamReader("./Json/Assets/Wynagrodzenie.json"))
            {
                string json = r.ReadToEnd();
                wynagrodzenia = JsonSerializer.Deserialize<List<WynagrodzenieE>>(json);
            }

            foreach(WynagrodzenieE wyn in wynagrodzenia){
                _db.Wynagrodzenia.Add(wyn);
                await _db.SaveChangesAsync();
            }
        }

        [HttpGet("dodajAllCeny")]
        public async void dodajAllCeny(){

         
          
             List<CenaProduktuE> cenyProduktow = new List<CenaProduktuE>();
            
               using (StreamReader r = new StreamReader("./Json/Assets/Ceny.json"))
            {
                string json = r.ReadToEnd();
                cenyProduktow = JsonSerializer.Deserialize<List<CenaProduktuE>>(json);
            }

            foreach(CenaProduktuE ceny in cenyProduktow){
                _db.CenyProduktow.Add(ceny);
                await _db.SaveChangesAsync();
            }
        }

    }
}