using Microsoft.AspNetCore.Http;
using RS1Seminarski.Modul_Smjestaj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.View_Models
{
    public class RezervacijaAddViewModel
    {
        public int PutovanjeId { get; set; }
       // public Putovanje Putovanje { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        //public IFormFile SlikaUplatnice { get; set; }
        public string SlikaUplatnice { get; set; }
    }
}
