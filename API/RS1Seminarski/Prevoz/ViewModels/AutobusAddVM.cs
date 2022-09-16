using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Prevoz.ViewModels
{
    public class AutobusAddVM
    {
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public bool Klima { get; set; }
        public bool WiFi { get; set; }
    }
}
