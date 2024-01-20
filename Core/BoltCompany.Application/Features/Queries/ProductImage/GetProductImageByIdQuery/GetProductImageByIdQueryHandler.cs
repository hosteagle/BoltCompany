using BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ProductImage.GetProductImageByIdQuery
{
    public class GetProductImageByIdQueryHandler : IRequestHandler<GetProductImageByIdQueryRequest, GetProductImageByIdQueryResponse>
    {
        private readonly IProductImageRepository _repository;

        public GetProductImageByIdQueryHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductImageByIdQueryResponse> Handle(GetProductImageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id.ToString());
            if (data == null) return new GetProductImageByIdQueryResponse { Message = "Product image is not exist", StatusCode = HttpStatusCode.NotFound };

            return new GetProductImageByIdQueryResponse { StatusCode = HttpStatusCode.OK, ProductImage = data };
        }
    }
}
