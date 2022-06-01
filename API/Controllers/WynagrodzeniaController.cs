using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class WynagrodzeniaController : BaseApiController
    {
         private readonly DataContext _context;

        public WynagrodzeniaController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("getWynagrodzenia")]
        public List<WynagrodzenieK> getWynagrodzenia(){
             List<WynagrodzenieK> wynagrodzenia = new List<WynagrodzenieK>();
            List<CenaProduktuK> ceny = new List<CenaProduktuK>();
            using (StreamReader r = new StreamReader("./Json/Assets/Wynagrodzenie.json"))
            {
                string json = r.ReadToEnd();
                wynagrodzenia = JsonSerializer.Deserialize<List<WynagrodzenieK>>(json);
            }
            using (StreamReader r = new StreamReader("./Json/Assets/Ceny.json"))
            {
                string json = r.ReadToEnd();
                ceny = JsonSerializer.Deserialize<List<CenaProduktuK>>(json);
            }




            List<string> nazwyWojewodztw = new List<string>();
            //List<Rok> lat = new List<Rok>();
            List<Wojewodztwo> woj = new List<Wojewodztwo>();

            for (int i = 0; i < ceny.Count; i++)
            {
                if (nazwyWojewodztw.Contains(ceny[i].Nazwa))
                {

                }
                else
                {
                    nazwyWojewodztw.Add(ceny[i].Nazwa);
                }
            }

            for (int i = 0; i < nazwyWojewodztw.Count; i++)
            {
                List<string> nazwylat = new List<string>();
                List<Rok> lat = new List<Rok>();

                for (int j = 0; j < wynagrodzenia.Count; j++)
                {
                    if (nazwylat.Contains(wynagrodzenia[j].Rok))
                    { }
                    else
                    {
                        nazwylat.Add(wynagrodzenia[j].Rok);
                    }
                }

                for (int j = 0; j < nazwylat.Count; j++)
                {
                    for (int l = 0; l < wynagrodzenia.Count; l++)
                    {
                        if (nazwyWojewodztw[i] == wynagrodzenia[l].Nazwa)
                        {
                            if (nazwylat[j] == wynagrodzenia[l].Rok)
                            {
                                //dodanie do roku wynagrodzenia 
                                //lat.Add(new Rok(wynagrodzenia[l].Rok, wynagrodzenia[l].Wartosc));


                                List <(string name, string cost)> produkty = new List<(string name, string cost)>();
                                //dodanie do roku listy produktow
                                for (int k = 0; k < ceny.Count; k++)
                                {
                                    if (nazwyWojewodztw[i] == ceny[k].Nazwa)
                                    {
                                        if (nazwylat[j] == ceny[k].Rok)
                                        {
                                            produkty.Add((ceny[k].RodzajeTowaru,ceny[k].Wartosc));
                                        }
                                    }
                                }

                                lat.Add(new Rok(wynagrodzenia[l].Rok, wynagrodzenia[l].Wartosc, produkty));
                            }
                            
                        }
                    }
                }
                woj.Add(new Wojewodztwo(nazwyWojewodztw[i], lat) );
            }

            for (int i = 0; i < woj.Count; i++)
            {
                woj[i].print();

            }
            return (wynagrodzenia);
            
        }
        [HttpGet("getWynagrodzenia/{nazwa}")]
        public List<WynagrodzenieK> getIndeks(string nazwa){
             List<WynagrodzenieK> wynagrodzenia = new List<WynagrodzenieK>();
            
            using (StreamReader r = new StreamReader("./Json/Assets/Wynagrodzenie.json"))
            {
                string json = r.ReadToEnd();
                wynagrodzenia = JsonSerializer.Deserialize<List<WynagrodzenieK>>(json);
            }
            return wynagrodzenia.FindAll(a=> a.Nazwa == nazwa);
        }
    }
}