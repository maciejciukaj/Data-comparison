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
        public List<Rok> Lata;

        public Wojewodztwo(string name, List<Rok> lata)
        {
            Name = name;
            Lata = lata;
        }

        public void print()
        {
            Console.WriteLine("{0}", Name);
            Lata.ForEach(x => x.print());
        }
    }
}
