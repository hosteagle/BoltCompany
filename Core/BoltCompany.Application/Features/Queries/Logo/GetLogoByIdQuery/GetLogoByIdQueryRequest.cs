using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Logo.GetLogoByIdQuery
{
    public class GetLogoByIdQueryRequest : IRequest<GetLogoByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
