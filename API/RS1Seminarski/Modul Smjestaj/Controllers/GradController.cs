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
    public class GradController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GradController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<Grad> Add([FromBody] GradVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var grad = new Grad
            {
                Naziv = x.naziv,
                PostanskiBroj = x.postanskiBroj,
                DrzavaId = x.drzavaId,
                Drzava = _dbContext.Drzave.Find(x.drzavaId)
            };
            _dbContext.Add(grad);
            _dbContext.SaveChanges();

            return grad;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            Grad grad = _dbContext.Gradovi.Find(id);

            if (grad == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(grad);

            _dbContext.SaveChanges();
            return Ok(grad);
        }

        [HttpGet]
        public List<Grad> GetAll()
        {

            var data = _dbContext.Gradovi.Include(x => x.Drzava)
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
