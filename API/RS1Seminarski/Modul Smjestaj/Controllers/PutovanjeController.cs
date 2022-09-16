using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Modul_Smjestaj.Models;
using RS1Seminarski.Modul_Smjestaj.View_Models;
using RS1Seminarski.Prevoz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PutovanjeController : ControllerBase
    {
        public ApplicationDbContext dbContext;

        public PutovanjeController(ApplicationDbContext _dbContext) {
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public ActionResult<PagedList<Putovanje>> GetAllPutovanjePaged(int items_per_page=3, int page_number = 1)
        {
            var data = dbContext.Putovanje.Include(p => p.PrevoznaSredstva).Include(p => p.Smjestaj).Include(p => p.Gradovi)
                .AsQueryable();
            return PagedList<Putovanje>.Create(data, page_number, items_per_page); 
        }
        [HttpGet]
        public ActionResult<List<Putovanje>> GetAllPutovanja()
        {
            var data = dbContext.Putovanje.Include(p => p.PrevoznaSredstva).Include(p => p.Smjestaj).Include(p => p.Gradovi)
                .AsQueryable().OrderByDescending(p => p.DatumOd);
            return data.Take(100).ToList();
        }
        [HttpGet]
        public ActionResult<PagedList<Putovanje>> GetBuducaPutovanjaPaged(int items_per_page = 10, int page_number = 1)
        {
            var data = dbContext.Putovanje.Include(p => p.PrevoznaSredstva).Include(p => p.Smjestaj).Include(p => p.Gradovi)
                .AsQueryable().Where(p => p.DatumOd > DateTime.Now);
            return PagedList<Putovanje>.Create(data, page_number, items_per_page);
        }
        [HttpGet]
        public ActionResult<List<Putovanje>> GetBuducaPutovanja()
        {
            var data = dbContext.Putovanje.Include(p=>p.PrevoznaSredstva)
                .Include(p=>p.Smjestaj).Include(p=>p.Gradovi).AsQueryable().Where(p => p.DatumOd > DateTime.Now);
            return data.Take(100).ToList();
        }
        [HttpGet]
        public ActionResult<PagedList<Putovanje>> GetProslaPutovanjaPaged(int items_per_page = 10, int page_number = 1)
        {
            var data = dbContext.Putovanje.Include(p => p.PrevoznaSredstva).Include(p => p.Smjestaj).Include(p => p.Gradovi)
                .AsQueryable().Where(p => p.DatumOd < DateTime.Now);
            return PagedList<Putovanje>.Create(data, page_number, items_per_page);
        }

        [HttpGet]
        public ActionResult<List<Putovanje>> GetProslaPutovanja()
        {
            var data = dbContext.Putovanje.Include(p => p.PrevoznaSredstva).Include(p => p.Smjestaj).Include(p => p.Gradovi)
                .AsQueryable().Where(p => p.DatumOd < DateTime.Now);
            return data.Take(100).ToList();
        }
        [HttpGet]
        public ActionResult<Putovanje> GetPutovanjeById(int putovanjeId)
        {
            var putovanje = dbContext.Putovanje.Include(p => p.PrevoznaSredstva).Include(p => p.Smjestaj).Include(p => p.Gradovi)
                .AsQueryable().FirstOrDefault(p => p.Id == putovanjeId);
            putovanje.Gradovi = GetGradoviByPutovanjeId(putovanjeId);
            return Ok(putovanje);
        }

        [HttpGet]
        public List<Putovanje> GetPosljednjePutovanje()
        {
            var data = dbContext.Putovanje.AsQueryable();
            return data.OrderByDescending(x=>x.Id).Take(1).ToList();
        }

        [HttpPost]

        public ActionResult<Putovanje> AddPutovanje([FromBody]PutovanjeVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var putovanje = new Putovanje
            {
                BrojPutnika = x.brojPutnika,
                Naziv=x.naziv,
                TipPutovanja=x.tipPutovanja,
                Cijena=x.cijena,
                DatumDo=x.datumDo,
                DatumOd=x.datumOd,
                Trajanje=x.trajanje,
                Slika = x.slika,
               
            };
            /*putovanje.Gradovi = new List<Grad>();
            var g = dbContext.Gradovi.Include(g => g.Drzava).FirstOrDefault(g => g.Id == x.gradovi);
            putovanje.Gradovi.Add(g);*/

           /* var putovanjeGrad = new PutovanjeGradovi
            {
                PutovanjeId = x.putovanjeId,
                Putovanje = dbContext.Putovanje.Find(x.putovanjeId),
                PrevoznoSredstvoId = x.prevoznoSredstvoId,
                PrevoznoSredstvo = dbContext.PrevoznoSredstvo.Find(x.prevoznoSredstvoId)
            };
           */

            dbContext.Add(putovanje);
            dbContext.SaveChanges();
            return Ok(putovanje);
        }

        [HttpGet]
        public List<PutovanjePrevoznoSredstvo> GetAllPutovanjePrevoz()
        {
            var data = dbContext.PutovanjePrevoznoSredstvo.Include(x=>x.PrevoznoSredstvo).Include(x=>x.Putovanje).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost]
        public ActionResult<Putovanje> AddPutovanjePrevoz([FromBody] PutovanjePrevoznoSredstvoVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var putovanjePrevoz = new PutovanjePrevoznoSredstvo
            {
                PutovanjeId = x.putovanjeId,
                Putovanje = dbContext.Putovanje.Find(x.putovanjeId),
                PrevoznoSredstvoId = x.prevoznoSredstvoId,
                PrevoznoSredstvo = dbContext.PrevoznoSredstvo.Find(x.prevoznoSredstvoId)
            };

           
            dbContext.Add(putovanjePrevoz);
            dbContext.SaveChanges();
            var putovanje = dbContext.Putovanje.FirstOrDefault(p => p.Id == x.putovanjeId);
            putovanje.PrevoznaSredstva = GetPrevozByPutovanjeId(x.putovanjeId);
            dbContext.SaveChanges();
           
 
            return putovanje;
        }

        [HttpGet]
        private List<PrevoznoSredstvo> GetPrevozByPutovanjeId(int putovanjeId)
        {
            var putovanjeprevoz = dbContext.PutovanjePrevoznoSredstvo.Where(p => p.PutovanjeId == putovanjeId).Include(pp=>pp.PrevoznoSredstvo).ToList();
            var prevoz = new List<PrevoznoSredstvo>();
            foreach(var pp in putovanjeprevoz)
            {
                prevoz.Add(pp.PrevoznoSredstvo);
            }
            return prevoz;
        }


        [HttpGet]
        public List<PutovanjeSmjestaj> GetAllPutovanjeSmjestaj()
        {
            var data = dbContext.PutovanjeSmjestaj.Include(x => x.Putovanje).Include(x => x.Smjestaj).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost]
        public ActionResult<Putovanje> AddPutovanjeSmjestaj([FromBody] PutovanjeSmjestajVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var putovanjeSmjestaj = new PutovanjeSmjestaj
            {
                PutovanjeId = x.putovanjeId,
                Putovanje = dbContext.Putovanje.Find(x.putovanjeId),
                SmjestajId = x.smjestajId,
                Smjestaj= dbContext.Smjestaj.Find(x.smjestajId)
            };


            dbContext.Add(putovanjeSmjestaj);
            dbContext.SaveChanges();
            var putovanje = dbContext.Putovanje.FirstOrDefault(p => p.Id == x.putovanjeId);
            putovanje.Smjestaj = GetSmjestajByPutovanjeId(x.putovanjeId);
            dbContext.SaveChanges();


            return putovanje;
        }

        [HttpGet]
        private List<Smjestaj> GetSmjestajByPutovanjeId(int putovanjeId)
        {
            var putovanjesmjestaj = dbContext.PutovanjeSmjestaj.Where(p => p.PutovanjeId == putovanjeId).Include(pp => pp.Smjestaj).ToList();
            var smjestaj = new List<Smjestaj>();
            foreach (var p in putovanjesmjestaj)
            {
                smjestaj.Add(p.Smjestaj);
            }
            return smjestaj;
        }


        [HttpGet]
        public List<PutovanjeGradovi> GetAllPutovanjeGradovi()
        {
            var data = dbContext.PutovanjeGradovi.Include(x => x.Putovanje).Include(x => x.Grad.Drzava.Naziv).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost]
        public ActionResult<Putovanje> AddPutovanjeGrad([FromBody] PutovanjeGradVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            var putovanjeGrad = new PutovanjeGradovi
            {
                PutovanjeId = x.PutovanjeId,
                Putovanje = dbContext.Putovanje.Find(x.PutovanjeId),
                GradId = x.GradId,
                Grad = dbContext.Gradovi.Include(g => g.Drzava).FirstOrDefault(g=>g.Id==x.GradId),
            };


            dbContext.Add(putovanjeGrad);
            dbContext.SaveChanges();
            var putovanje = dbContext.Putovanje.FirstOrDefault(p => p.Id == x.PutovanjeId);
            putovanje.Gradovi = GetGradoviByPutovanjeId(x.PutovanjeId);
            dbContext.SaveChanges();


            return putovanje;
        }

        [HttpGet]
        public List<Grad> GetGradoviByPutovanjeId(int putovanjeId)
        {
            var putovanjegrad = dbContext.PutovanjeGradovi.Where(p => p.PutovanjeId == putovanjeId).Include(pp => pp.Grad.Drzava).ToList();
            var gradovi = new List<Grad>();
            foreach (var p in putovanjegrad)
            {
                gradovi.Add(p.Grad);
            }
            return gradovi;
        }

        [HttpPost("{id}")]
        public ActionResult AddPutovanjeImage(int id, [FromForm] PutovanjeImageAddVM x)
        {
            /*if (!HttpContext.GetLoginInfo().isPermisijaStudentskaSluzba)
                return BadRequest("nije logiran");*/
            try
            {
                Putovanje  putovanje = dbContext.Putovanje.FirstOrDefault(s => s.Id == id);

                if (x.slika_putovanje != null && putovanje != null)
                {
                    if (x.slika_putovanje.Length > 300 * 1000)
                        return BadRequest("max velicina fajla je 300 KB");

                    string ekstenzija = Path.GetExtension(x.slika_putovanje.FileName);

                    var filename = $"{Guid.NewGuid()}{ekstenzija}";

                    x.slika_putovanje.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                    putovanje.Slika = Config.SlikeURL + filename;
                    dbContext.SaveChanges();
                }

                return Ok(putovanje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        [HttpGet]
        public ActionResult<List<int>> PutovanjaByMjesec(int year)
        {
            var list = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var data = dbContext.Putovanje.Where(p => p.DatumOd.Year == year)
                 .AsQueryable();
            foreach (var p in data)
            {
                var mjesec = p.DatumOd.Month;
                list[mjesec - 1] += 1;
            }
            return Ok(list);
        }

        [HttpGet]
        public ActionResult<List<int>> RevenueByMonth(int year)
        {
            var list = new List<double>() {0,0,0,0,0,0,0,0,0,0,0,0 };
            var data = dbContext.Putovanje.Where(p => p.DatumOd.Year == year).Where(p => p.DatumDo < DateTime.Now)
                 .AsQueryable();
            foreach (var p in data)
            {
                var brLjudi = dbContext.Rezervacija.Where(r => r.PutovanjeId == p.Id).Count();
                var revenue = brLjudi * p.Cijena;
                list[p.DatumOd.Month - 1] += revenue;
            }
            return Ok(list);
        }

        [HttpGet]
        public ActionResult<List<string>> Top5Putovanja(int year)
        {
            var list = new List<PutniciDestinacijaVM>();
            var data = dbContext.Putovanje.Where(p => p.DatumOd.Year == year).Where(p => p.DatumDo < DateTime.Now)
                 .AsQueryable();
            foreach (var p in data)
            {
                var brLjudi = dbContext.Rezervacija.Where(r => r.PutovanjeId == p.Id).Count();
                list.Add(new PutniciDestinacijaVM(){ brLjudi=brLjudi, putovanjeNaziv=p.Naziv});
            }
           
            return Ok(list.OrderByDescending(p => p.brLjudi).Take(5));
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            Putovanje p = dbContext.Putovanje.Find(id);


            if (p == null)
                return BadRequest("pogresan ID");
            foreach(var pp in dbContext.PutovanjePrevoznoSredstvo)
            {
                if (pp.PutovanjeId == id)
                {
                    dbContext.Remove(pp);
                }
            }
            foreach (var pp in dbContext.PutovanjeGradovi)
            {
                if (pp.PutovanjeId == id)
                {
                    dbContext.Remove(pp);
                }
            }
            foreach (var pp in dbContext.PutovanjeSmjestaj)
            {
                if (pp.PutovanjeId == id)
                {
                    dbContext.Remove(pp);
                }
            }

            dbContext.Remove(p);

            dbContext.SaveChanges();
            return Ok(p);
        }

        [HttpDelete]
        public ActionResult DeletePrevozPutovanje(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return BadRequest("Niste admin!");
            }
            PutovanjePrevoznoSredstvo p = dbContext.PutovanjePrevoznoSredstvo.Find(id);

            if (p == null)
                return BadRequest("pogresan ID");

            dbContext.Remove(p);

            dbContext.SaveChanges();
            return Ok(p);
        }

        [HttpPost]
        public ActionResult<PlanProgram> AddPlanProgram([FromBody] PlanProgramVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaVodic)
                return BadRequest("vodic nije logiran");
            var upit = dbContext.PlanProgram.Where(p => p.PutovanjeId == x.PutovanjeId).Count();
            if(upit>4)
            {
                return BadRequest("Previse planova i programa");
            }
            var plan = new PlanProgram
            {
                Id=x.Id,
                Name=x.Name,
                Text=x.Text,
                PutovanjeId=x.PutovanjeId,
                Putovanje=dbContext.Putovanje.Where(a=>a.Id==x.PutovanjeId).FirstOrDefault()
            };
            dbContext.Add(plan);
            dbContext.SaveChanges();
            return Ok(plan);
        }


        [HttpGet]
        public List<PlanProgram> GetPlanProgramById(int putovanjeId)
        {
            var planProgram = dbContext.PlanProgram.
                Where(p => p.PutovanjeId == putovanjeId).ToList();
            return planProgram;
        }

        [HttpDelete]
        public ActionResult DeletePlanProgram(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaVodic)
                return BadRequest("vodic nije logiran");
            PlanProgram p = dbContext.PlanProgram.Find(id);

            if (p == null)
                return BadRequest("pogresan ID");

            dbContext.Remove(p);

            dbContext.SaveChanges();
            return Ok(p);
        }

    }
}
