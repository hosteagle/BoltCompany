using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ExtraPage.UpdateExtraPageCommand
{
    public class UpdateExtraPageCommandRequest : IRequest<UpdateExtraPageCommandResponse>
    {
        public Guid Id { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
    }
}
