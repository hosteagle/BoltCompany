using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPagesQuery
{
    public class GetExtraPagesQueryHandler : IRequestHandler<GetExtraPagesQueryRequest, GetExtraPagesQueryResponse>
    {
        public Task<GetExtraPagesQueryResponse> Handle(GetExtraPagesQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
