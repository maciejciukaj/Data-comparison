using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class CenaProduktuK
    {
        public int Id {get; set;}
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string RodzajeTowaru { get; set; }
        public string Rok { get; set; }
        public string Wartosc { get; set; }
        //public string Jednostkamiary { get; set; }

        public void Wyswietl()
        {
            Console.WriteLine("Kod = {0}", Kod);
            Console.WriteLine("Nazwa = {0}", Nazwa);
            Console.WriteLine("RodzajeTowaru = {0}", RodzajeTowaru);
            Console.WriteLine("Rok = {0}", Rok);
            Console.WriteLine("Wartosc = {0}", Wartosc);
           // Console.WriteLine("Jednostka miary = {0}",Jednostkamiary);
        }

    }

    
}
