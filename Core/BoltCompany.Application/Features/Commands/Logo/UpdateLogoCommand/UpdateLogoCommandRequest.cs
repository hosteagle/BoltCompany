using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Logo.UpdateLogoCommand
{
    public class UpdateLogoCommandRequest : IRequest<UpdateLogoCommandResponse>
    {
        public Guid Id { get; set; }
        public IFormFile Logo { get; set; }
        public IFormFile Icon { get; set; }
    }
}
