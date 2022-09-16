using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Models
{
    public class Drzava
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
    }
}
