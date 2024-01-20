using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Category.GetCategoriesQuery
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, GetCategoriesQueryResponse>
    {
        private readonly ICategoryRepository _repsitory;

        public GetCategoriesQueryHandler(ICategoryRepository repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task<GetCategoriesQueryResponse> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repsitory.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetCategoriesQueryResponse { Categories = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
