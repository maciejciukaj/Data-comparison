using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CenyController : BaseApiController
    {
         private readonly DataContext _context;

        public CenyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getCeny")]
        public List<CenaProduktuK> getCeny(){
             
            List<CenaProduktuK> ceny = new List<CenaProduktuK>();
           
            using (StreamReader r = new StreamReader("./Json/Assets/Ceny.json"))
            {
                string json = r.ReadToEnd();
                ceny = JsonSerializer.Deserialize<List<CenaProduktuK>>(json);
            }

            return (ceny);
            
        }
        [HttpGet("getCeny/{nazwa}")]
        public List<CenaProduktuK> getIndeks(string nazwa){
             List<CenaProduktuK> ceny = new List<CenaProduktuK>();
            
               using (StreamReader r = new StreamReader("./Json/Assets/Ceny.json"))
            {
                string json = r.ReadToEnd();
                ceny = JsonSerializer.Deserialize<List<CenaProduktuK>>(json);
            }
            return ceny.FindAll(a=> a.Nazwa == nazwa);
        }

         [HttpGet("getCenyBaza")]
        public async Task<ActionResult<IEnumerable<Entities.CenaProduktuE>>> GetCenyBaza(){
            
            return await _context.CenyProduktow.ToListAsync();
        }
    

        
    }
}