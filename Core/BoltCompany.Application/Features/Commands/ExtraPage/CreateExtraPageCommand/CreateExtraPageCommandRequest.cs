using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ExtraPage.CreateExtraPageCommand
{
    public class CreateExtraPageCommandRequest : IRequest<CreateExtraPageCommandResponse>
    {
        public string PageName { get; set; }
        public string PageTitle { get; set; }
    }
}
