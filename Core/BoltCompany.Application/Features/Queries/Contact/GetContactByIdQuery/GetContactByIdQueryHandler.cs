using BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Contact.GetContactByIdQuery
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQueryRequest, GetContactByIdQueryResponse>
    {
        private readonly IContactRepository _repository;

        public GetContactByIdQueryHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResponse> Handle(GetContactByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id.ToString());
            if (data == null) return new GetContactByIdQueryResponse { Message = "Contact is not exist", StatusCode = HttpStatusCode.NotFound };

            return new GetContactByIdQueryResponse { StatusCode = HttpStatusCode.OK, Contact = data };
        }
    }
}
