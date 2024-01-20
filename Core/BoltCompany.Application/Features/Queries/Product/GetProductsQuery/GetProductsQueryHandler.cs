using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Product.GetProductsQuery
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
    {
        private readonly IProductRepository _repsitory;

        public GetProductsQueryHandler(IProductRepository repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repsitory.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetProductsQueryResponse { Products = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
