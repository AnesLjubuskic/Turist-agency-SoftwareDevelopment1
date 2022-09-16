using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.Modul.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class RacunController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RacunController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Racun> Add([FromBody] RacunAddVM x)
        {
            var racun = new Racun()
            {
                DatumIzdavanja=x.datumIzdavanja,
                Iznos=x.iznos
               
            };

            _dbContext.Add(racun);
            _dbContext.SaveChanges();
            return racun;
        }

        [HttpGet]
        public List<Racun> GetAll()
        {
            var data = _dbContext.Racun
                .AsQueryable();
            return data.Take(100).ToList();
        }

      
    }
}
