﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.View_Models
{
    public class PutovanjeImageAddVM
    {
        public IFormFile slika_putovanje { set; get; }
    }
}
