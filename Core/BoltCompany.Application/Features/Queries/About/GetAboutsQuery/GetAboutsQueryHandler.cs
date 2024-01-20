using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.About.GetAboutsQuery
{
    public class GetAboutsQueryHandler : IRequestHandler<GetAboutsQueryRequest, GetAboutsQueryResponse>
    {
        private readonly IAboutRepository _repsitory;

        public GetAboutsQueryHandler(IAboutRepository repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task<GetAboutsQueryResponse> Handle(GetAboutsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repsitory.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetAboutsQueryResponse { Abouts = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
