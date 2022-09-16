using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.TestniPodaci
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestniPodaciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult DodajAdmina()
        {
            
            var admini = new List<Admin>();
            Random rnd = new Random();

            admini.Add(new Admin
            {
                KorisnickoIme = "admin",
                Lozinka = "test123",
                Slika = Config.SlikeFolder + "empty.png",
                isAdmin = true,
                isVodic = false,
                Ime = "Admin",
                Prezime = "Admin",
                DatumRodjenja = new DateTime(rnd.Next(1980, 2000), rnd.Next(1, 13), rnd.Next(1, 29)),
                DatumZaposlenja = DateTime.Now,
                Email = "turisticka.sem@gmail.com",
                BrojTelefona = "000/000-000",
                isTwoStep = true
            });

            _dbContext.AddRange(admini);
            _dbContext.SaveChanges();

            return Ok(admini);
        }

        [HttpPut]
        public ActionResult EmailAdminPromjena()
        {

            var admin = _dbContext.Administratori.Where(a => a.KorisnickoIme == "admin").First();


            admin.Email = "turisticka.sem@gmail.com";

            _dbContext.SaveChanges();

            return Ok(admin);
        }
    }

  
}

