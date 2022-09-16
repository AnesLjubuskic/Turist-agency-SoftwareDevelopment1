using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.ModulAutentifikacija.Models
{
    public class AutentifikacijaToken
    {
        internal object korisnickiNalog;

        [Key]
        public int Id { get; set; }
        public string Vrijednost { get; set; }

        [ForeignKey(nameof(KorisnickiNalogId))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IpAdresa { get; set; }

    }
}
