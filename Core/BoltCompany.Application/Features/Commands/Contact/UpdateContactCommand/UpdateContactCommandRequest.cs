using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Contact.UpdateContactCommand
{
    public class UpdateContactCommandRequest : IRequest<UpdateContactCommandResponse>
    {
        public Guid Id { get; set; }
        public string ContactType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
