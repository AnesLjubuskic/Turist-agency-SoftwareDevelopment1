using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.Modul.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AplikacijaPosaoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AplikacijaPosaoController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<AplikacijaPosao> Add([FromBody] AplikacijaPosaoAddVM x)
        {
            var apposao = new AplikacijaPosao()
            {
                
                Ime = x.ime,
                Prezime = x.prezime,
                Zanimanje=x.zanimanje,
                CV=x.cv
            };

            _dbContext.Add(apposao);
            _dbContext.SaveChanges();

            return apposao;
        }

        [HttpGet]
        public ActionResult<PagedList<AplikacijaPosao>> GetAllPaged(int items_per_page = 10, int page_number = 1)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaAdmin)
                return BadRequest("admin nije logiran");
            var data = _dbContext.AplikacijaPosao
                .AsQueryable();
            return PagedList<AplikacijaPosao>.Create(data, page_number, items_per_page);
        }

        [HttpGet]
        public ActionResult<AplikacijaPosao> GetAll()
        {
            var data = _dbContext.AplikacijaPosao
                .AsQueryable();
            return Ok(data);
        }

        [HttpPost("{id}")]
        public ActionResult AddProfileImage(int id, [FromForm] AplikacijaPosaoImageAddVM x)
        {
            try
            {
                AplikacijaPosao apposao = _dbContext.AplikacijaPosao.FirstOrDefault(s => s.Id == id);

                if (x.slika_posao != null && apposao != null)
                {
                    if (x.slika_posao.Length > 300 * 1000)
                        return BadRequest("max velicina fajla je 300 KB");

                    string ekstenzija = Path.GetExtension(x.slika_posao.FileName);

                    var filename = $"{Guid.NewGuid()}{ekstenzija}";

                    x.slika_posao.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                    apposao.CV = Config.SlikeURL + filename;
                    _dbContext.SaveChanges();
                }

                return Ok(apposao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
    }
}
