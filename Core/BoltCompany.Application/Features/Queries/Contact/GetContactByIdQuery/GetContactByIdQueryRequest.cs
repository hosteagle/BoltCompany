using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Contact.GetContactByIdQuery
{
    public class GetContactByIdQueryRequest : IRequest<GetContactByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
