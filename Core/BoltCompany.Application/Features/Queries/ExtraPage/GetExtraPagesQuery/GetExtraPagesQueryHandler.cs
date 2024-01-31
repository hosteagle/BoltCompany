using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPagesQuery
{
    public class GetExtraPagesQueryHandler : IRequestHandler<GetExtraPagesQueryRequest, GetExtraPagesQueryResponse>
    {
        private readonly IExtraPageRepository _repository;

        public GetExtraPagesQueryHandler(IExtraPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetExtraPagesQueryResponse> Handle(GetExtraPagesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetExtraPagesQueryResponse { ExtraPages = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
