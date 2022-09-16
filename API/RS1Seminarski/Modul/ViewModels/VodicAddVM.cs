using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.ViewModels
{
    public class VodicAddVM
    {
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }
        //public IFormFile slika { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public string slika { get; set; }
    }
}
