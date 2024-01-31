using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Contact.GetContactsQuery
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQueryRequest, GetContactsQueryResponse>
    {
        public Task<GetContactsQueryResponse> Handle(GetContactsQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
