using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ExtraPage.DeleteExtraPageCommand
{
    public class DeleteExtraPageCommandRequest : IRequest<DeleteExtraPageCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
