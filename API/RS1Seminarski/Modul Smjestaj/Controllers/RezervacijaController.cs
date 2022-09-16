using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Hubs;
using RS1Seminarski.Modul_Smjestaj.Email;
using RS1Seminarski.Modul_Smjestaj.Models;
using RS1Seminarski.Modul_Smjestaj.Services.FileService;
using RS1Seminarski.Modul_Smjestaj.View_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RezervacijaController : ControllerBase
    {
        public ApplicationDbContext _dbContext;
        private readonly IEmail _email;
        private readonly IFileService _file;

        public RezervacijaController(ApplicationDbContext dbContext, IEmail email, IFileService file)
        {
            _dbContext = dbContext;
            _email = email;
            _file = file;
        }

        [HttpGet]
        public List<Rezervacija> GetAllRezervacije()
        {
            var data = _dbContext.Rezervacija.Include(p => p.Putovanje).AsQueryable();
            return data.Take(100).ToList();
            
        }
        [HttpGet]
        public ActionResult<PagedList<Rezervacija>> GetAllRezervacijePaged(int items_per_page = 10, int page_number = 1)
        {

            var data = _dbContext.Rezervacija
                .Include(p => p.Putovanje).AsQueryable();
            return PagedList<Rezervacija>.Create(data, page_number, items_per_page);
        }

        [HttpGet]
        public ActionResult<PagedList<Rezervacija>> GetAllUplatePaged(int items_per_page = 10, int page_number = 1)
        {
            var data = _dbContext.Rezervacija.Include(p => p.Putovanje).Where(x=>x.Odobreno).AsQueryable();
            return PagedList<Rezervacija>.Create(data, page_number, items_per_page);
        }

        [HttpPost]
        public ActionResult<Grupe> AddUser(int id, string name, string lastname)
        {
            var grupa = _dbContext.GrupePutovanja.Find(id);
            var osoba = new Osoba
            {
                Ime = name,
                Prezime = lastname
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

        [HttpPost]

        public async Task<ActionResult> AddRezervaciju([FromBody] RezervacijaAddViewModel x)
        {
            Rezervacija rezervacija;
            try
            {
                rezervacija = new Rezervacija()
                {
                    PutovanjeId = x.PutovanjeId,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    BrojTelefona = x.BrojTelefona,
                    Email = x.Email,                    
                    SlikaUplatnice = x.SlikaUplatnice
                };

                var grupe = _dbContext.GrupePutovanja.Where(c => c.PutovajeId == x.PutovanjeId && c.Korisnici.Count()<c.BrojPutnika).FirstOrDefault();

                if(grupe!=null)
                {
                    AddUser(grupe.Id, x.Ime, x.Prezime);
                }
                else
                {
                    BadRequest("Nema slobodnih mjesta");
                }
               
                _dbContext.Add(rezervacija);
                _dbContext.SaveChanges();
                 await _email.Send("Rezervisali ste putovanje", "Uspjesno ste izvrsili rezervaciju putovanja", x.Email);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ex.InnerException);
            }
            return Ok(rezervacija);

        }

        [HttpGet]
        public ActionResult<Rezervacija> GetRezervacijaById(int id)
        {
            var rezervacija = _dbContext.Rezervacija.Include(p => p.Putovanje).Where(r => r.Id == id).FirstOrDefault();
            return Ok(rezervacija);
        }

        [HttpPost("{id}")]
        public ActionResult AddRezervacijaSlika(int id, [FromForm] RezervacijaSlikaAddViewModel x)
        {

            try
            {
                Rezervacija rezervacija = _dbContext.Rezervacija.Include(p => p.Putovanje).FirstOrDefault(s => s.Id == id);

                if (x.SlikaUplatnice != null && rezervacija != null)
                {
                    if (x.SlikaUplatnice.Length > 300 * 1000)
                        return BadRequest("max velicina fajla je 300 KB");

                    string ekstenzija = Path.GetExtension(x.SlikaUplatnice.FileName);

                    var filename = $"{Guid.NewGuid()}{ekstenzija}";

                    x.SlikaUplatnice.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                    rezervacija.SlikaUplatnice = Config.SlikeURL + filename;
                    _dbContext.SaveChanges();
                }

                return Ok(rezervacija);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
                return BadRequest("nije logiran");

            Rezervacija rezervacija = _dbContext.Rezervacija.Find(id);

            if (rezervacija == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(rezervacija);

            _dbContext.SaveChanges();
            return Ok(rezervacija);
        }

        [HttpGet]
        public List<Rezervacija> GetAllRezervacijeByPutovanjeId(int id)
        {
            var data = _dbContext.Rezervacija.Include(p => p.Putovanje).Where(x => x.PutovanjeId == id).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public List<Rezervacija> GetUplate()
        {
            var data = _dbContext.Rezervacija.Include(p => p.Putovanje).Where(x => x.Odobreno == true).AsQueryable();
            return data.Take(100).ToList();
        }


        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] RezervacijaUpdateViewModel x)
        {

            Rezervacija rezervacija;

            rezervacija = _dbContext.Rezervacija.Include(s => s.Putovanje).FirstOrDefault(s => s.Id == id);

            if (rezervacija == null)
                return BadRequest("pogresan ID");


            rezervacija.Datum = DateTime.Now;
            rezervacija.Odobreno = true;
            rezervacija.Iznos = x.Iznos;

            _dbContext.SaveChanges();
            return Ok(rezervacija);
        }



    }



}
