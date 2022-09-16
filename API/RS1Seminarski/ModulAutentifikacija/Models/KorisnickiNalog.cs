using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.ModulAutentifikacija.Models
{
    public class KorisnickiNalog
    {
        [Key]
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Slika { get; set; }
        public bool isAdmin { get; set; }
        public bool isVodic { get; set; }
        public bool isTwoStep { get; set; } = false;
        public int? twoStep { get; set; }
        public string Email { get; set; }

    }
}
