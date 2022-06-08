using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Json.Assets;

namespace API
{
    public class Pobierz
    {
       public  static List<Wojewodztwo> Download()
        {
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


                                List<Produkt> produkty = new List<Produkt>();
                                //dodanie do roku listy produktow
                                for (int k = 0; k < ceny.Count; k++)
                                {
                                    if (nazwyWojewodztw[i] == ceny[k].Nazwa)
                                    {
                                        if (nazwylat[j] == ceny[k].Rok)
                                        {
                                            produkty.Add(new Produkt(ceny[k].RodzajeTowaru, ceny[k].Wartosc));
                                        }
                                    }
                                }

                                lat.Add(new Rok(wynagrodzenia[l].Rok, wynagrodzenia[l].Wartosc, produkty));
                            }

                        }
                    }
                }
                woj.Add(new Wojewodztwo(nazwyWojewodztw[i], lat));
            }

            return woj;

        }
    }
}
