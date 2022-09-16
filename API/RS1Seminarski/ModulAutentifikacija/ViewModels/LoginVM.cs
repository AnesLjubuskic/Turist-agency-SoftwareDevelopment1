using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.ModulAutentifikacija.ViewModels
{
    public class LoginVM
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }

    public class LoginTwoStepVM
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int twoStep { get; set; }

    }

    public class MailVM
    {
        public int id { get; set; }

    }
}
