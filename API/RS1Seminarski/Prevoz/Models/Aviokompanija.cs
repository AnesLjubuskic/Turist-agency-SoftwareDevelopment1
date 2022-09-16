using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Prevoz.Models
{
    public class Aviokompanija:PrevoznoSredstvo
    {
 
        public string Telefon { get; set; }
        public string Mail { get; set; }
    }
}
