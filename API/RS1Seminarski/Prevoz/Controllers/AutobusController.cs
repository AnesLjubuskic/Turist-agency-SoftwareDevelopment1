using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Prevoz.Models;
using RS1Seminarski.Prevoz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Prevoz.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AutobusController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AutobusController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpPost]
        public ActionResult<Autobus> Add([FromBody] AutobusAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var autobus = new Autobus
            {
                Naziv = x.Naziv,
                Kapacitet = x.Kapacitet,
                Klima = x.Klima,
                WiFi = x.WiFi
            };
            _dbContext.Add(autobus);
            _dbContext.SaveChanges();

            return autobus;
        }


        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            Autobus autobus = _dbContext.Autobus.Find(id);

            if (autobus == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(autobus);

            _dbContext.SaveChanges();
            return Ok(autobus);
        }

        [HttpGet]
        public List<Autobus> GetAll()
        {

            var data = _dbContext.Autobus
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public List<PrevoznoSredstvo> GetPrevoz()
        {

            var data = _dbContext.PrevoznoSredstvo
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
