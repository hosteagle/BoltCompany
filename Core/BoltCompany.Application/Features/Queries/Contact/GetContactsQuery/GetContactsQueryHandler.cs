using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Contact.GetContactsQuery
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQueryRequest, GetContactsQueryResponse>
    {
        private readonly IContactRepository _repository;

        public GetContactsQueryHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetContactsQueryResponse> Handle(GetContactsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync(c => c.IsDeleted == false, false);

            return new GetContactsQueryResponse { Contacts = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
