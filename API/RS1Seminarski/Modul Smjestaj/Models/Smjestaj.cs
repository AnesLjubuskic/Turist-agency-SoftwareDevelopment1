using RS1Seminarski.Modul_Smjestaj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Models
{
    public class Smjestaj
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Opis { get; set; }
        public int Kapacitet { get; set; }
        public string Adresa { get; set; }
        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}
