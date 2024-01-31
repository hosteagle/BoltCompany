using BoltCompany.Application.Repositories;
using MediatR;
using System.Net;

namespace BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailByIdQuery
{
    public class GetPageDetailByIdQueryHandler : IRequestHandler<GetPageDetailByIdQueryRequest, GetPageDetailByIdQueryResponse>
    {
        private readonly IPageDetailRepository _repository;

        public GetPageDetailByIdQueryHandler(IPageDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPageDetailByIdQueryResponse> Handle(GetPageDetailByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id.ToString());
            if (data == null) return new GetPageDetailByIdQueryResponse { Message = "Page detail is not exist", StatusCode = HttpStatusCode.NotFound };

            return new GetPageDetailByIdQueryResponse { StatusCode = HttpStatusCode.OK, PageDetail = data };
        }
    }
}
