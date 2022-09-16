using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Models
{
    public class Grad
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
    }
}
