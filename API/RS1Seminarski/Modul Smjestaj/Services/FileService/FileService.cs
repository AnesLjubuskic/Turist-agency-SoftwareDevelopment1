using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RS1Seminarski.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Modul_Smjestaj.Services.FileService
{
    public class FileService:IFileService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var webRootPath = _webHostEnvironment.WebRootPath;
            var uploadsDirectoryPath = _configuration.GetSection("Uploads").GetSection("DirectoryPath").Value;

            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(webRootPath, uploadsDirectoryPath, fileName);

            var directoryPath = Path.GetDirectoryName(filePath);
            if (directoryPath == null)
                return null;

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            await using (var fileStream = new FileStream(Config.SlikeFolder + fileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return NormalizePath(Path.GetRelativePath(webRootPath, filePath));
        }
        private string NormalizePath(string path)
        {
            return "/" + path.Replace(Path.DirectorySeparatorChar, '/');
        }
    }
}
