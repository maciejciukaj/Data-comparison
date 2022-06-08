using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Json.Assets;

namespace API
{
    public class Rok
    {
        public string Year { get; set; }

        public string Pay { get; set; }

        public double SredniaCenaProduktow { get; set; }

        public double IloscProduktowNaPensje { get; set; }

        public List<Produkt> Produkty { get; set; }

        public Rok()
        {
            
        }

        public Rok(string year, string pay, List<Produkt> produkt)
        {
            Year = year;
            Pay = pay;
            Produkty = produkt;
            SredniaCenaProduktow = 0;
            int pusteProdukty = 0;
            for (int k = 0; k < Produkty.Count; k++)
            {
                if(Produkty[k].Cena != "-")
                {
                    SredniaCenaProduktow += double.Parse(Produkty[k].Cena, System.Globalization.CultureInfo.InvariantCulture);
                    
                }
                else 
                {
                    pusteProdukty++;
                }
                     
            }

            if (pusteProdukty == Produkty.Count)
                SredniaCenaProduktow = 0;
            else
                SredniaCenaProduktow /= (Produkty.Count - pusteProdukty);


            if(Pay != "-")
                IloscProduktowNaPensje = double.Parse(Pay, System.Globalization.CultureInfo.InvariantCulture) / SredniaCenaProduktow;
            else
                IloscProduktowNaPensje = 0;

            IloscProduktowNaPensje = Math.Round(IloscProduktowNaPensje, 2);

            SredniaCenaProduktow = Math.Round(SredniaCenaProduktow, 2);
        }


        public void print()
        {
            Console.WriteLine(" {0}", Year);
            Console.WriteLine("  Zarobki = {0}", Pay);
            Console.WriteLine("  Srednia cena produktow = {0}", SredniaCenaProduktow);
            Console.WriteLine("  Ilosc Produktow na pensje = {0}", IloscProduktowNaPensje);
            for (int i = 0; i < Produkty.Count; i++)
            {
                Console.WriteLine("    {0}:{1}",Produkty[i].Nazwa, Produkty[i].Cena);
            }
        }


    }
}
