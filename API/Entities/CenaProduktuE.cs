using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class CenaProduktuE
    {

        public int Id {get; set;}

        public string Kod {get; set;}

        public string Nazwa {get; set;}

        public string RodzajeTowaru {get; set;}

        public string Rok {get; set;}

        public string Wartosc {get; set;}
        
    }
}