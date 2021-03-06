using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DbController : BaseApiController
    {
        private readonly DataContext _db;

   
    public DbController(DataContext db)
    {
        _db = db;
    }
        [Authorize]
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
        
        [Authorize]
        [HttpPost("dodajCeneProduktu")]
        public async Task<ActionResult<CenaProduktuE>> dodajCeneProduktu(CenaProduktuE cena){

           

            var cenaN = new CenaProduktuE{
                Kod = cena.Kod,
                Nazwa = cena.Nazwa,
                RodzajeTowaru = cena.RodzajeTowaru,
                Rok = cena.Rok,
                Wartosc = cena.Wartosc

            };
            _db.CenyProduktow.Add(cenaN);
            await _db.SaveChangesAsync();

            return new CenaProduktuE{
               
                Kod = cenaN.Kod,
                Nazwa = cenaN.Nazwa,
                RodzajeTowaru = cenaN.RodzajeTowaru,
                Rok = cenaN.Rok,
                Wartosc = cenaN.Wartosc

            };

        }



        [HttpPost("dodajAllWynagrodzenia")]
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

       
        [HttpPost("dodajAllCeny")]
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

        [Authorize]
        [HttpDelete("usunWynagrodzenie/{idW}")]
        public  async void usunWynagrodzenie(int idW){
            var wynToRemove = _db.Wynagrodzenia.SingleOrDefault(x => x.Id == idW);
           if(wynToRemove != null){
            _db.Wynagrodzenia.Remove(wynToRemove);
            await _db.SaveChangesAsync();
            }
           
        }

        [Authorize]
        [HttpDelete("usunProdukt/{idW}")]
        public  async void usunProdukt(int idW){
            var wynToRemove = _db.CenyProduktow.SingleOrDefault(x => x.Id == idW);
           if(wynToRemove != null){
            _db.CenyProduktow.Remove(wynToRemove);
            await _db.SaveChangesAsync();
            }
           
        }
        [Authorize]
        [HttpGet("saveJson")]
        public void saveToJson(){
            List<Wojewodztwo> newListToJson = Pobierz.Download();
            Zapisz.SaveJSON(newListToJson);
        }

        [Authorize]
        [HttpGet("saveXML")]
        public void saveToXML(){
            List<Wojewodztwo> newListToJson = Pobierz.Download();
            Zapisz.SaveXML(newListToJson);
        }

    }
}