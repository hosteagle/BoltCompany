using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ProductImage.GetProductImagesByProductIdQuery
{
    public class GetProductImagesByProductIdQueryRequest : IRequest<GetProductImagesByProductIdQueryResponse>
    {
        public Guid ProductId { get; set; }
    }
}
