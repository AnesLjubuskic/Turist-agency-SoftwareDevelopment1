using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Services.FileService
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
