using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.About.CreateAboutCommand
{
    public class CreateAboutCommandRequest : IRequest<CreateAboutCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
