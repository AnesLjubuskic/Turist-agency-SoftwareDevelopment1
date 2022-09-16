using RS1Seminarski.Prevoz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Models
{
    public class Putovanje
    {
        //public Putovanje()
        //{
        //    PutovSm = new HashSet<PutovanjeSmjestaj>();
        //    PutovPrij = new HashSet<PutovanjePrevoznoSredstvo>();
        //}
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string TipPutovanja { get; set; }
        public int BrojPutnika { get; set; }
        public double Cijena { get; set; }
        public DateTime DatumOd { get; set; }
        public int Trajanje { get; set; }
        public DateTime DatumDo { get; set; }
        public List<PrevoznoSredstvo> PrevoznaSredstva { get; set; }
        public List<Smjestaj> Smjestaj { get; set; }
        public List<Grad> Gradovi { get; set; }
        public List<PlanProgram> PlanProgrami { get; set; }

        public string Slika { get; set; }

    }
}
