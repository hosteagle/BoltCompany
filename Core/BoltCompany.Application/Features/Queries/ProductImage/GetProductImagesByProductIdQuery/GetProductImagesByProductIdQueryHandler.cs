using BoltCompany.Application.Features.Queries.ProductImage.GetProductImagesQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ProductImage.GetProductImagesByProductIdQuery
{
    public class GetProductImagesByProductIdQueryHandler : IRequestHandler<GetProductImagesByProductIdQueryRequest, GetProductImagesByProductIdQueryResponse>
    {
        private readonly IProductImageRepository _repository;

        public GetProductImagesByProductIdQueryHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductImagesByProductIdQueryResponse> Handle(GetProductImagesByProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync(c => c.IsDeleted == false && c.ProductId == request.ProductId, false);

            return new GetProductImagesByProductIdQueryResponse { ProductImages = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
