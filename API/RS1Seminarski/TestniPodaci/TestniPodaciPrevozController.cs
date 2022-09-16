using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Prevoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.TestniPodaci
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestniPodaciPrevozController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciPrevozController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult DodajBusAvio()
        {
            var putovanja = _dbContext.Putovanje.ToList();
            var autobusi = new List<Autobus>();
            var aviokompanije = new List<Aviokompanija>();

            autobusi.Add(new Autobus
            {
                Naziv = "AutobusA",
                Kapacitet = 60,
                Klima = true,
                WiFi = true
            });
            autobusi.Add(new Autobus
            {
                Naziv = "AutobusB",
                Kapacitet = 55,
                Klima = true,
                WiFi = true
            });
            aviokompanije.Add(new Aviokompanija
            {
                Naziv = "Kompanija1",
                Telefon = "111/222-333",
                Mail = "info@kompanija.ba",
                Kapacitet = 100
            });
            aviokompanije.Add(new Aviokompanija
            {
                Naziv = "Kompanija2",
                Telefon = "000/222-333",
                Mail = "info2@kompanija.ba",
                Kapacitet = 95
            });

            _dbContext.AddRange(autobusi);
            _dbContext.AddRange(aviokompanije);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
