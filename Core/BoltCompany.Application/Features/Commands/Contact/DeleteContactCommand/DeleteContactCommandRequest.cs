using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Contact.DeleteContactCommand
{
    public class DeleteContactCommandRequest : IRequest<DeleteContactCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
