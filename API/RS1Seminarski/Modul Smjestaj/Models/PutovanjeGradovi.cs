using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Models
{
    public class PutovanjeGradovi
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Putovanje))]
        public int PutovanjeId { get; set; }
        public Putovanje Putovanje { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }

    }
}
