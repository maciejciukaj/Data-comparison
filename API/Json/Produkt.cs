using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Json.Assets
{
    public class Produkt
    {
         public string Nazwa { get; set; }

        public string Cena { get; set; }

        public Produkt()
        {

        }

        public Produkt(string nazwa,string cena)
        {
            Nazwa = nazwa;
            Cena = cena;
        }
    }
}