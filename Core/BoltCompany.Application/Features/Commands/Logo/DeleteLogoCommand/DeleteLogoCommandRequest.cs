using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Logo.DeleteLogoCommand
{
    public class DeleteLogoCommandRequest : IRequest<DeleteLogoCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
