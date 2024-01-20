using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ProductImage.CreateProductImageCommand
{
    public class CreateProductImageCommandRequest : IRequest<CreateProductImageCommandResponse>
    {
        public IFormFile ImgFile { get; set; }
        public bool IsCoverImage { get; set; }
        public Guid ProductId { get; set; }
    }
}
