using BoltCompany.Application.Abstractions.Token;
using BoltCompany.Application.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Infrastructure.Services.File
{
    public class FileService : IFileService
    {
        private string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        public async Task<string> UploadAsync(IFormFile file, FileType fileType)
        {
            string uploadsFolder = "";
            if (file == null || file.Length == 0)
                throw new ArgumentNullException("file", "Dosya seçilmedi.");

            if (fileType == FileType.Product)
            {
                uploadsFolder = Path.Combine(uploadsPath, "products");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);
            }
            else if (fileType == FileType.Logo)
            {
                uploadsFolder = Path.Combine(uploadsPath, "logos");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);
            }
            else if (fileType == FileType.Page)
            {
                uploadsFolder = Path.Combine(uploadsPath, "pages");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
