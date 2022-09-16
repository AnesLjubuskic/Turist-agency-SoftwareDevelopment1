using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Sadrzaj { get; set; }
    }
}
