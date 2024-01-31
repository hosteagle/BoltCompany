using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPageByIdQuery
{
    public class GetExtraPageByIdQueryRequest : IRequest<GetExtraPageByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
