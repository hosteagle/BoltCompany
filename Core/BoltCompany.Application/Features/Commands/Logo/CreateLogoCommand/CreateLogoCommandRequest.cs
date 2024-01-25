using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Logo.CreateLogoCommand
{
    public class CreateLogoCommandRequest : IRequest<CreateLogoCommandResponse>
    {
        public IFormFile Logo { get; set; }
        public IFormFile Icon { get; set; }
    }
}
