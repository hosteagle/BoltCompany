using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Logo.GetLogosQuery
{
    public class GetLogosQueryHandler : IRequestHandler<GetLogosQueryRequest, GetLogosQueryResponse>
    {
        private readonly ILogoRepository _repository;

        public GetLogosQueryHandler(ILogoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLogosQueryResponse> Handle(GetLogosQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetLogosQueryResponse { Logos = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
