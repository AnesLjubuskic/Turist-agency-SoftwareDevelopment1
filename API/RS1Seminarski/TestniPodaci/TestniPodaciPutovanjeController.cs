using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Modul_Smjestaj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.TestniPodaci
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestniPodaciPutovanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciPutovanjeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult DodajPutovanje()
        {
            var putovanje = new List<Putovanje>();

            putovanje.Add(new Putovanje
            {
                Naziv="Grande Tour",
                TipPutovanja="Ne znam sta ovo predstavlja",
                BrojPutnika=69,
                Cijena=200,
                DatumOd=new DateTime(2022,3,1),
                DatumDo=new DateTime(2022,3,5),
                Trajanje=4
            });

            putovanje.Add(new Putovanje
            {
                Naziv = "Tura1",
                TipPutovanja = "Ne znam",
                BrojPutnika = 123,
                Cijena = 250,
                DatumOd = new DateTime(2022, 5, 1),
                DatumDo = new DateTime(2022, 5, 5),
                Trajanje = 4
            });

            _dbContext.AddRange(putovanje);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
