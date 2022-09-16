using RS1Seminarski.Modul_Smjestaj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Prevoz.Models
{
    public class PrevoznoSredstvo
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
    }
}
