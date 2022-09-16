using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public AdminController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public List<Admin> GetAll()
        {
            var data = _dbContext.Administratori
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public Admin GetFirst()
        {
            var data = _dbContext.Administratori
                .AsQueryable();
            return data.FirstOrDefault();
        }

        [HttpGet]
        public Admin GetAdminById(int id)
        {
            var data = _dbContext.Administratori.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        [HttpGet("{name}")]
        public KorisnickiNalog GetKorisnikByName(string name)
        {
            var data = _dbContext.KorisnickiNalog.Where(x => x.KorisnickoIme.ToLower() == name.ToLower()).FirstOrDefault();
            return data;
        }

        [HttpGet("{id}")]
        public KorisnickiNalog GetKorisnikById(int id)
        {
            var user = _dbContext.KorisnickiNalog.FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}
