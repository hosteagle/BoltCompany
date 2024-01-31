using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailsQuery
{
    public class GetPageDetailsQueryHandler : IRequestHandler<GetPageDetailsQueryRequest, GetPageDetailsQueryResponse>
    {
        public Task<GetPageDetailsQueryResponse> Handle(GetPageDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
