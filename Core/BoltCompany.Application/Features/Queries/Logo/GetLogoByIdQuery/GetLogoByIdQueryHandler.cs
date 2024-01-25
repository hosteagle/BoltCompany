using BoltCompany.Application.Features.Queries.ProductImage.GetProductImageByIdQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Logo.GetLogoByIdQuery
{
    public class GetLogoByIdQueryHandler : IRequestHandler<GetLogoByIdQueryRequest, GetLogoByIdQueryResponse>
    {
        private readonly ILogoRepository _repository;

        public GetLogoByIdQueryHandler(ILogoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLogoByIdQueryResponse> Handle(GetLogoByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id.ToString());
            if (data == null) return new GetLogoByIdQueryResponse { Message = "Logo is not exist", StatusCode = HttpStatusCode.NotFound };

            return new GetLogoByIdQueryResponse { StatusCode = HttpStatusCode.OK, Logo = data };
        }
    }
}
