using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Wojewodztwo
    {
         public string Name { get; set; }
        public List<Rok> Lata { get; set; }


        //Średni wzrost zarboków = (Zarobki z 2021 - Zarobki z 2011)/Zarobki z 2011
        public double WzrostZarobkowNa10Lat { get; set; }

        //Średni wzrost cen = (Ceny z 2021 - Ceny z 2011)/Ceny z 2011
        public double WzrostCenNa10Lat { get; set; }

        //Średni Ilosc produktow za srednia pensje = Pensja/CenapProduktów
        public double SredniaIloscProduktowNaPensje { get; set; }


        public Wojewodztwo()
        {
            
        }
        public Wojewodztwo(string name, List<Rok> lata)
        {
            Name = name;
            Lata = lata;

            int i = 1;
            int j = 0;
            bool czyMoznaPay = true;
            bool czyMoznaCeny = true;
            while(Lata[Lata.Count - i].Pay == "-")
            {
                
                if(Lata.Count - i == 1)
                {
                    czyMoznaPay = false;
                    break;
                }
                i++;
            }
           
            if(czyMoznaPay)
            {
                while (Lata[j].Pay == "-")
                {
                    
                    if (Lata.Count == j-2)
                    {
                        czyMoznaPay = false;
                        break;
                    }
                    j++;
                }
            }

            int k = 1;
            int l = 0;

            while (Lata[Lata.Count - k].SredniaCenaProduktow == 0)
            {
                
                if (Lata.Count - k == 1)
                {
                    czyMoznaCeny = false;
                    break;
                }
                k++;
            }

            if (czyMoznaCeny)
            {
                while (Lata[l].SredniaCenaProduktow == 0)
                {
                    
                    if (Lata.Count == l - 2)
                    {
                        czyMoznaCeny = false;
                        break;
                    }
                    l++;
                }
            }

            if(czyMoznaCeny)
            {
                WzrostCenNa10Lat = (Lata[Lata.Count - k].SredniaCenaProduktow - Lata[l].SredniaCenaProduktow) / Lata[l].SredniaCenaProduktow;
                WzrostCenNa10Lat *= 100;
                WzrostCenNa10Lat = Math.Round(WzrostCenNa10Lat, 2);
            }

            if (czyMoznaPay)
            {
                WzrostZarobkowNa10Lat = (double.Parse(Lata[Lata.Count - i].Pay, System.Globalization.CultureInfo.InvariantCulture) - double.Parse(Lata[j].Pay, System.Globalization.CultureInfo.InvariantCulture)) / double.Parse(Lata[j].Pay, System.Globalization.CultureInfo.InvariantCulture);
                WzrostZarobkowNa10Lat *= 100;
                WzrostZarobkowNa10Lat = Math.Round(WzrostZarobkowNa10Lat, 2);
            }

            SredniaIloscProduktowNaPensje = 0;
            int pustelata = 0;
            for (int y = 0; y < Lata.Count; y++)
            {
                if (Lata[y].IloscProduktowNaPensje == 0)
                {
                    pustelata++;
                }
                else
                    SredniaIloscProduktowNaPensje += Lata[y].IloscProduktowNaPensje;
            }
            SredniaIloscProduktowNaPensje /= (Lata.Count-pustelata);
            
        }

        public void print()
        {
            Console.WriteLine("{0}", Name);
            Console.WriteLine(" Wzrost zarobkow na przestrzeni 10 lat = {0}", WzrostZarobkowNa10Lat);
            Console.WriteLine(" Wzrost cen na przestrzeni 10 lat = {0}", WzrostCenNa10Lat);
            Console.WriteLine(" Srednia ilosc produktow na pensje przez 10 lat = {0}", SredniaIloscProduktowNaPensje);
            Lata.ForEach(x => x.print());
        }
    }
}
