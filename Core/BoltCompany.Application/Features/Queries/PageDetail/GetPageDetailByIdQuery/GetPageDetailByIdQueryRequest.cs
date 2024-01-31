using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailByIdQuery
{
    public class GetPageDetailByIdQueryRequest : IRequest<GetPageDetailByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
