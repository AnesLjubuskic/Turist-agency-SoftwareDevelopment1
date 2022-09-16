using RS1Seminarski.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Models
{
    [Table("Admin")]
    public class Admin:KorisnickiNalog
    {

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string BrojTelefona { get; set; }
    }
}
