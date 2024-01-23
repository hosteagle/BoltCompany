using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ProductImage.UpdateProductImageCommand
{
    public class UpdateProductImageCommandRequest : IRequest<UpdateProductImageCommandResponse>
    {
        public Guid Id { get; set; }
        public List<IFormFile> Files { get; set; }
        public bool IsCoverImage { get; set; }
        public Guid ProductId { get; set; }
    }
}
