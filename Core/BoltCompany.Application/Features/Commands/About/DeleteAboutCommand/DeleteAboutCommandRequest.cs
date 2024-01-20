using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.About.DeleteAboutCommand
{
    public class DeleteAboutCommandRequest : IRequest<DeleteAboutCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
