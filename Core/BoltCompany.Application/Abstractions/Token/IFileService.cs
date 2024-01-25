using BoltCompany.Application.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Abstractions.Token
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, FileType fileType);
    }
}
