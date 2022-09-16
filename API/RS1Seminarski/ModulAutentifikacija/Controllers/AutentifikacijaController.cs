using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.Modul_Smjestaj.Email;
using RS1Seminarski.ModulAutentifikacija.Models;
using RS1Seminarski.ModulAutentifikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RS1Seminarski.Helper.MyAuthTokenExtension;

namespace RS1Seminarski.ModulAutentifikacija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class AutentifikacijaController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IEmail _email;
        public AutentifikacijaController (ApplicationDbContext dbContext, IEmail email)
        {
            this._dbContext = dbContext;
            _email = email;
        }


        //[HttpPost]

        //public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        //{
        //    KorisnickiNalog logiraniKorisnik = _dbContext.KorisnickiNalog.SingleOrDefault(k => k.KorisnickoIme != null && k.KorisnickoIme == x.KorisnickoIme && k.Lozinka == x.Lozinka);

        //    if (logiraniKorisnik == null)
        //    {
        //        return new LoginInformacije(null);
        //    }
        //    string randomString = TokenGenerator.Generate(10);


        //    var noviToken = new AutentifikacijaToken()
        //    {
        //        IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
        //        Vrijednost = randomString,
        //        KorisnickiNalog = logiraniKorisnik,
        //        VrijemeEvidentiranja = DateTime.Now
        //    };

        //    _dbContext.Add(noviToken);
        //    _dbContext.SaveChanges();

        //    return new LoginInformacije(noviToken);

        //}

        [HttpPost("Login")]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {
            //1- provjera logina
            KorisnickiNalog logiraniKorisnik = _dbContext.KorisnickiNalog.FirstOrDefault(k => k.KorisnickoIme != null && k.KorisnickoIme == x.KorisnickoIme && k.Lozinka == x.Lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return null;
            }


            //2- generisati random string
            string randomString = TokenGenerator.Generate(10);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AutentifikacijaToken()
            {
                IpAdresa = "1.2.3.4",
                Vrijednost = randomString,
                KorisnickiNalog = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now
            };

            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();

            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }

        [HttpPost("LoginTwoStep")]
        public ActionResult<LoginInformacije> LoginTwoStep([FromBody] LoginTwoStepVM x)
        {
            //1- provjera logina
            KorisnickiNalog logiraniKorisnik = 
                _dbContext.KorisnickiNalog
                .FirstOrDefault(k => k.KorisnickoIme != null 
                                && k.KorisnickoIme == x.KorisnickoIme 
                                && k.Lozinka == x.Lozinka
                                && k.twoStep==x.twoStep);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return null;
            }


            //2- generisati random string
            string randomString = TokenGenerator.Generate(10);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AutentifikacijaToken()
            {
                IpAdresa = "1.2.3.4",
                Vrijednost = randomString,
                KorisnickiNalog = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now
            };

            //promjena 2step sifre
            Random rnd = new Random();
            var sifra = rnd.Next(1000, 9999);
            logiraniKorisnik.twoStep = sifra;
            //
            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();

            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }




        [HttpPost("Logout")]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacija = HttpContext.GetAuthToken();
            return autentifikacija;
        }

        [HttpPost("SendTwoStep")]

        public async Task<ActionResult> SendTwoStep([FromBody] MailVM x)
        {
            var data = _dbContext.Vodici.First(s=>s.Id==x.id);
            try
            {
                Random rnd = new Random();
                var sifra = rnd.Next(1000, 9999);
                if (data.isTwoStep)
                {
                    data.twoStep = sifra;
                    _dbContext.SaveChanges();
                    await _email.Send("Zastitna lozinka", "Vasa druga lozinka je : " + sifra, data.Email);
                }
            }
            catch
            {
                return BadRequest("Greska");
            }
            return Ok(data);
        }

        [HttpPost("SendTwoStepAdmin")]

        public async Task<ActionResult> SendTwoStepAdmin([FromBody] MailVM x)
        {
            var data = _dbContext.Administratori.First(s => s.Id == x.id);
            try
            {
                Random rnd = new Random();
                var sifra = rnd.Next(1000, 9999);
                if (data.isTwoStep)
                {
                    data.twoStep = sifra;
                    _dbContext.SaveChanges();
                    await _email.Send("Zastitna lozinka", "Vasa druga lozinka je : " + sifra, data.Email);
                }
            }
            catch
            {
                return BadRequest("Greska");
            }
            return Ok(data);
        }

        [HttpPost("ActivateTwoStep")]
        public ActionResult ActivateTwoStep([FromBody] TwoStepVM x)
        {
            var osoba = _dbContext.Vodici.Where(s=>s.Id==x.id).First();
           
            if (osoba.isTwoStep)
            {
                osoba.isTwoStep = false;
            }
            else if(!osoba.isTwoStep)
            {
                osoba.isTwoStep = true;
            }

            _dbContext.SaveChanges();
            return Ok(osoba);
        }

        
    }
}
