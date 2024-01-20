using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery
{
    public class GetAboutByIdQueryRequest : IRequest<GetAboutByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
