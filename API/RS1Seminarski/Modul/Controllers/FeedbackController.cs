using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1Seminarski.Data;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.Modul.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public FeedbackController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpPost]

        public ActionResult Postavi([FromBody] FeedbackVM x)
        {
            var feedback = new Feedback();
            dbContext.Add(feedback);
            feedback.Ime = x.Ime;
            feedback.Sadrzaj = x.Sadrzaj;
            dbContext.SaveChanges();
            return Ok(feedback);
        }

        [HttpGet]
        public ActionResult<Feedback> GetAll()
        {
            var data = dbContext.Feedback.ToList();
            return Ok(data);
        }
    }
}
