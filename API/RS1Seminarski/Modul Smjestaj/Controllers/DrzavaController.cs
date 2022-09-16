using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    [ApiController]
    public class DrzavaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DrzavaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Drzava> Add([FromBody] DrzavaVM x)
        {
            /* if (!HttpContext.GetLoginInfo().isPermisijaStudentskaSluzba)
                 return BadRequest("nije logiran");*/
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var drzava = new Drzava
            {
                Naziv = x.naziv,
                Oznaka = x.oznaka
            };

            _dbContext.Add(drzava);
            _dbContext.SaveChanges();
            return drzava;
        }


        [HttpGet]
        public List<Drzava> GetAll()
        {

            var data = _dbContext.Drzave
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            Drzava drzava = _dbContext.Drzave.Find(id);

            if (drzava == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(drzava);

            _dbContext.SaveChanges();
            return Ok(drzava);
        }
    }
}
