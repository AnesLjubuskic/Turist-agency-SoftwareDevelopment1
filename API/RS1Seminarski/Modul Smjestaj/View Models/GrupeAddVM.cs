using RS1Seminarski.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.View_Models
{
    public class GrupeAddVM
    {
        public int PutovajeId { get; set; }
        public int VodicId { get; set; }
        public int BrojPutnika { get; set; }
        public List<KorisnickiNalog> Korisnici { get; set; }
    }
}
