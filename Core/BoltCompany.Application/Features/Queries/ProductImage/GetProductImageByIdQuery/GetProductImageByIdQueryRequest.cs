using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ProductImage.GetProductImageByIdQuery
{
    public class GetProductImageByIdQueryRequest : IRequest<GetProductImageByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
