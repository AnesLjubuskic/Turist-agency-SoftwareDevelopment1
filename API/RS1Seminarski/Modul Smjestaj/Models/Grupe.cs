using RS1Seminarski.Modul.Models;
using RS1Seminarski.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Models
{
    public class Grupe
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Putovanje))]
        public int PutovajeId { get; set; }
        public Putovanje Putovanje { get; set; }
        [ForeignKey(nameof(Vodic))]
        public int VodicId { get; set; }
        public Vodic Vodic { get; set; }
        public List<Osoba> Korisnici { get; set; }
        public int BrojPutnika { get; set; }
    }
}
