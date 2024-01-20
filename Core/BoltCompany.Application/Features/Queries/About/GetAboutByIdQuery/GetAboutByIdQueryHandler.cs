using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQueryRequest, GetAboutByIdQueryResponse>
    {
        private readonly IAboutRepository _repository;

        public GetAboutByIdQueryHandler(IAboutRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResponse> Handle(GetAboutByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id.ToString());
            if (data == null) return new GetAboutByIdQueryResponse { Message = "About is not exist", StatusCode = HttpStatusCode.NotFound };

            return new GetAboutByIdQueryResponse { StatusCode = HttpStatusCode.OK, About = data };
        }
    }
}
