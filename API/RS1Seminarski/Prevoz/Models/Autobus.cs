using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Prevoz.Models
{
    public class Autobus:PrevoznoSredstvo
    {
        
        public bool Klima { get; set; }
        public bool  WiFi { get; set; }
    }
}
