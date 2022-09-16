using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.Modul.ViewModels;
using RS1Seminarski.Modul_Smjestaj.Email;
using RS1Seminarski.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VodicController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmail _email;

        public VodicController(ApplicationDbContext dbContext,IEmail email)
        {
            _email = email;
            this._dbContext = dbContext;
        }


        [HttpGet]
        public List<Vodic> GetAll()
        {

            //var data = _dbContext.KorisnickiNalog.Where(x => x.isVodic).AsQueryable();
            //return data.Take(100).ToList();

            var data = _dbContext.Vodici.Where(x => x.isVodic).AsQueryable();
            return data.Take(100).ToList();
        }



        [HttpPost]
        public async Task<ActionResult> AddVodic([FromBody] VodicAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
                return BadRequest("admin nije logiran");

            if (_dbContext.Vodici.Where(v => v.KorisnickoIme == x.korisnickoIme).Count() != 0)
            {
                return BadRequest("Postoji korisnik sa tim korisničkim imenom");
            }

            var vodic = new Vodic();


            /*if (x.slika != null)
            {
                string ekstenzija = Path.GetExtension(x.slika.FileName);

                var filename = $"{Guid.NewGuid()}{ekstenzija}";
                string folder = "wwwroot/profile_images/";

                x.slika.CopyTo(new FileStream(folder + filename, FileMode.Create));
                vodic.Slika = filename;
            }
            */
            try
            {
                vodic.KorisnickoIme = x.korisnickoIme;
                vodic.Lozinka = x.lozinka;
                vodic.isAdmin = false;
                vodic.isVodic = true;
                vodic.Ime = x.ime;
                vodic.Prezime = x.prezime;
                vodic.DatumRodjenja = x.datumRodjenja;
                vodic.DatumZaposlenja = DateTime.Now;
                vodic.Email = x.email;
                vodic.BrojTelefona = x.brojTelefona;
                vodic.Slika = x.slika;

                _dbContext.Add(vodic);
                _dbContext.SaveChanges();
                await _email.Send("Travelpoint - vodič starter", "Dodani ste kao vodič u turističkoj agenciji Travelpoint. Vaši kredencijali za logovanje su username: " + x.korisnickoIme + ", password: " + x.lozinka, x.email);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
            return Ok(vodic);
        }


       /* [HttpPost("AddProfileImage")]
        public ActionResult AddProfileImage(int id, [FromForm] ImageAddVM x)
        {
           /* if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
                return BadRequest("nije logiran");
           
            try
            {
                Vodic vodic = _dbContext.Vodici.FirstOrDefault(s => s.Id == id);

                if (x.slika != null && vodic != null)
                {
                    if (x.slika.Length > 300 * 1000)
                        return BadRequest("max velicina fajla je 300 KB");

                    string ekstenzija = Path.GetExtension(x.slika.FileName);

                    var filename = $"{Guid.NewGuid()}{ekstenzija}";

                    x.slika.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                    vodic.Slika = Config.SlikeURL + filename;
                    _dbContext.SaveChanges();
                }

                return Ok(vodic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
       */
        [HttpPost("delete")]
        public ActionResult Delete(int id)
        {
            /* if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
                        return BadRequest("nije logiran");*/


            Vodic vodic = _dbContext.Vodici.FirstOrDefault(v => v.Id == id);

            if (vodic == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(vodic);

            _dbContext.SaveChanges();
            return Ok(vodic);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return Forbid();

            return Ok(_dbContext.Vodici.FirstOrDefault(s => s.Id == id));
        }
        


    }
}
