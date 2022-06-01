using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Rok
    {
        public string Year { get; set; }

        public string Pay { get; set; }

        public List<(string name, string cost)> Produkt { get; set; }

        public Rok(string year,string pay, List<(string name, string cost)> produkt)
        {
            Year = year;
            Pay = pay;
            Produkt = produkt;
        }

        public Rok(string year, string pay)
        {
            Year = year;
            Pay = pay;
        }

        public void print()
        {
            Console.WriteLine(" {0}", Year);
            Console.WriteLine("  Zarobki = {0}", Pay);
            for(int i = 0; i < Produkt.Count; i++)
            {
                Console.WriteLine("    {0}:{1}",Produkt[i].name, Produkt[i].cost);
            }
        }


    }
}
