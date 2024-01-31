using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.PageDetail.DeletePageDetailCommand
{
    public class DeletePageDetailCommandRequest : IRequest<DeletePageDetailCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
