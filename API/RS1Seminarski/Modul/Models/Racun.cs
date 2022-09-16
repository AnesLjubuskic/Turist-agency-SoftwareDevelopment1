using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Models
{
    public class Racun
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public double Iznos { get; set; }
    }
}
