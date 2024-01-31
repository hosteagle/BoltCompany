using BoltCompany.Application.Repositories;
using MediatR;
using System.Net;

namespace BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailsQuery
{
    public class GetPageDetailsQueryHandler : IRequestHandler<GetPageDetailsQueryRequest, GetPageDetailsQueryResponse>
    {
        private readonly IPageDetailRepository _repository;

        public GetPageDetailsQueryHandler(IPageDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPageDetailsQueryResponse> Handle(GetPageDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetPageDetailsQueryResponse { PageDetails = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
