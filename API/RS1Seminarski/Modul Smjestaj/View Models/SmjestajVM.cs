using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.View_Models
{
    public class SmjestajVM
    {
        public string naziv { get; set; }
        public string tip { get; set; }
        public string opis { get; set; }
        public int kapacitet { get; set; }
        public string adresa { get; set; }
        public int gradId { get; set; }
    }
}
