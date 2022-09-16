using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Modul_Smjestaj.Models;
using RS1Seminarski.Modul_Smjestaj.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SmjestajController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public SmjestajController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Smjestaj> Add([FromBody] SmjestajVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var smjestaj = new Smjestaj
            {
                Naziv = x.naziv,
                Tip = x.tip,
                Opis = x.opis,
                Kapacitet = x.kapacitet,
                Adresa = x.adresa,
                GradId = x.gradId,
                Grad = _dbContext.Gradovi.Find(x.gradId),
                
                
            };
            int drzavaId = smjestaj.Grad.DrzavaId;
            smjestaj.Grad.Drzava = _dbContext.Drzave.Find(drzavaId);
            _dbContext.Add(smjestaj);
            _dbContext.SaveChanges();

            return smjestaj;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            Smjestaj s = _dbContext.Smjestaj.Find(id);

            if (s == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(s);

            _dbContext.SaveChanges();
            return Ok(s);
        }

        [HttpGet]
        public List<Smjestaj> GetAll()
        {

            var data = _dbContext.Smjestaj.Include(x => x.Grad).Include(x => x.Grad.Drzava)
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
