using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Product.GetProductWithCategoryNameByIdQuery
{
    public class GetProductWithCategoryNameByIdQueryRequest : IRequest<GetProductWithCategoryNameByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
