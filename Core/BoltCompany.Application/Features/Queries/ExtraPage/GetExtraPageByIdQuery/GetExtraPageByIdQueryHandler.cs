using BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPageByIdQuery
{
    public class GetExtraPageByIdQueryHandler : IRequestHandler<GetExtraPageByIdQueryRequest, GetExtraPageByIdQueryResponse>
    {
        private readonly IExtraPageRepository _repository;

        public GetExtraPageByIdQueryHandler(IExtraPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetExtraPageByIdQueryResponse> Handle(GetExtraPageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id.ToString());
            if (data == null) return new GetExtraPageByIdQueryResponse { Message = "Extra page is not exist", StatusCode = HttpStatusCode.NotFound };

            return new GetExtraPageByIdQueryResponse { StatusCode = HttpStatusCode.OK, ExtraPage = data };
        }
    }
}
