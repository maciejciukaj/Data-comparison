using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            
            using (StreamReader r = new StreamReader("./Json/Assets/Wynagrodzenie.json"))
            {
                string json = r.ReadToEnd();
                wynagrodzenia = JsonSerializer.Deserialize<List<WynagrodzenieK>>(json);
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

        [Authorize]
        [HttpGet("getWynagrodzeniaBaza")]
        public async Task<ActionResult<IEnumerable<Entities.WynagrodzenieE>>> GetWynagrodzeniaBaza(){
            
            return await _context.Wynagrodzenia.ToListAsync();
        }

        
        [Authorize]
        [HttpGet("getWynagrodzeniaBaza/{nazwa}")]
        public async Task<ActionResult<IEnumerable<Entities.WynagrodzenieE>>> GetWynagrodzeniaBazaNazwa(string nazwa){
            
            return await _context.Wynagrodzenia.Where(a => a.Nazwa == nazwa).ToListAsync();
        }
    }
}