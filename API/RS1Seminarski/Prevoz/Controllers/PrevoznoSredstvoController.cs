using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Prevoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RS1Seminarski.Helper;
using System.Threading.Tasks;

namespace RS1Seminarski.Prevoz.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PrevoznoSredstvoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PrevoznoSredstvoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<PrevoznoSredstvo> GetAll()
        {

            var data = _dbContext.PrevoznoSredstvo
                .AsQueryable();
            return data.Take(100).ToList();
        }

    }
}
