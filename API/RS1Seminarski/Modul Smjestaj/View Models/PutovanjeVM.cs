using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.View_Models
{
    public class PutovanjeVM
    {
        public string naziv { get; set; }
        public string tipPutovanja { get; set; }
        public int brojPutnika { get; set; }
        public double cijena { get; set; }
        public DateTime datumOd { get; set; }
        public int trajanje { get; set; }
        public DateTime datumDo { get; set; }
        public string slika { get; set; }
        public int gradovi { get; set; }
    }
}
