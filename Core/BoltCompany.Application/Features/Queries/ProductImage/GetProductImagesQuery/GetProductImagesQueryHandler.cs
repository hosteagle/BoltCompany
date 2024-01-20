using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ProductImage.GetProductImagesQuery
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, GetProductImagesQueryResponse>
    {
        private readonly IProductImageRepository _repsitory;

        public GetProductImagesQueryHandler(IProductImageRepository repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task<GetProductImagesQueryResponse> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repsitory.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetProductImagesQueryResponse { ProductImages = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
