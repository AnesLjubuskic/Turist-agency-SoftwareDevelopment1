using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Prevoz.Models;
using RS1Seminarski.Prevoz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS1Seminarski.Helper;


namespace RS1Seminarski.Prevoz.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AviokompanijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AviokompanijaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]

        public ActionResult<Aviokompanija> Add([FromBody] AviokompanijaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var aviokompanija = new Aviokompanija
            {
                Naziv = x.Naziv,
                Kapacitet = x.Kapacitet,
                Mail = x.Mail,
                Telefon = x.Telefon
            };
            _dbContext.Add(aviokompanija);
            _dbContext.SaveChanges();

            return Ok(aviokompanija);

        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            Aviokompanija aviokompanija = _dbContext.Aviokompanija.Find(id);

            if (aviokompanija == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(aviokompanija);

            _dbContext.SaveChanges();
            return Ok(aviokompanija);
        }

        [HttpGet]
        public List<Aviokompanija> GetAll()
        {

            var data = _dbContext.Aviokompanija
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
