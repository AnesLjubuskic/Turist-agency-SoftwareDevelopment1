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
    public class TestniPodaciSmjestajController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciSmjestajController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult DodajSveZaSmjestaj()
        {
            var drzave = new List<Drzava>();
            var gradovi = new List<Grad>();
            var smjestaj = new List<Smjestaj>();
            drzave.Add(new Drzava
            {
                Naziv="Bosna i Hercegovina",
                Oznaka="BiH"
            });

            drzave.Add(new Drzava
            {
                Naziv = "Njemačka",
                Oznaka = "GM"
            });

            drzave.Add(new Drzava
            {
                Naziv = "Italija",
                Oznaka = "IT"
            });

            gradovi.Add(new Grad
            {
                Drzava = drzave[0],
                Naziv = "Bugojno",
                PostanskiBroj = "70230"
            });

            gradovi.Add(new Grad
            {
                Drzava = drzave[1],
                Naziv = "Dortmund",
                PostanskiBroj = "44001"
            });

            gradovi.Add(new Grad
            {
                Drzava = drzave[0],
                Naziv = "Rim",
                PostanskiBroj = "00199"
            });

            smjestaj.Add(new Smjestaj
            {
                Naziv = "Hotel Villa Grande",
                Tip = "Hotel",
                Opis = "Srednja zalost",
                Kapacitet = 200,
                Adresa = "Glavna Ulica Br.1",
                Grad = gradovi[0]
            });

            _dbContext.AddRange(drzave);
            _dbContext.AddRange(gradovi);
            _dbContext.AddRange(smjestaj);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
