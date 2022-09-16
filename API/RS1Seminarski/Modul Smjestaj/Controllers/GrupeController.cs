using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Modul_Smjestaj.Models;
using RS1Seminarski.Modul_Smjestaj.View_Models;
using RS1Seminarski.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GrupeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public GrupeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public List<Grupe> GetAll()
        {
            var data = _dbContext.GrupePutovanja
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public Grupe GetFirst()
        {
            var data = _dbContext.GrupePutovanja
                .AsQueryable();
            return data.FirstOrDefault();
        }

        [HttpGet]
        public Grupe GetAdminById(int id)
        {
            var data = _dbContext.GrupePutovanja.Where(x => x.Id == id).FirstOrDefault();
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
        [HttpGet("{id}")]
        public List<Grupe> GetByPutovanjeId(int id)
        {
            var grupa = _dbContext.GrupePutovanja.Where(x => x.PutovajeId == id).AsQueryable();
            return grupa.Take(100).ToList();
        }

        [HttpPost]
        public ActionResult<Grupe> Add([FromBody] GrupeAddVM x)
        {

            //if (!HttpContext.GetLoginInfo().isPermisijaVodic)
            //{
            //    return BadRequest("Niste admin!");
            //}
            var grupa = new Grupe
            {
                VodicId = x.VodicId,
                PutovajeId = x.PutovajeId,
                BrojPutnika = x.BrojPutnika
            };


            _dbContext.Add(grupa);
            _dbContext.SaveChanges();
            return Ok(grupa);
        }

        [HttpPost]
        public ActionResult<Grupe> AddUser(int id, string name, string lastname)
        {
            var grupa = _dbContext.GrupePutovanja.Find(id);
            var osoba=new Osoba{
                Ime=name,
                Prezime=lastname
            };
            _dbContext.Add(osoba);
            _dbContext.SaveChanges();
            if (grupa.Korisnici == null)
                grupa.Korisnici = new List<Osoba>();
            grupa.Korisnici.Add(osoba);
            _dbContext.Update(grupa);
            _dbContext.SaveChanges();
            return Ok(grupa);

        }

        [HttpGet]
        public ActionResult<PagedList<Grupe>> GetAllGrupePaged(int items_per_page = 10, int page_number = 1)
        {

            var data = _dbContext.GrupePutovanja
                .Include(p => p.Putovanje).Include(v=>v.Vodic).AsQueryable();
            return PagedList<Grupe>.Create(data, page_number, items_per_page);
        }
    }
}
