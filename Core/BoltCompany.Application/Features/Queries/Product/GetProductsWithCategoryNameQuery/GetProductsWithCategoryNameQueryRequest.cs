using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Product.GetProductsWithCategoryNameQuery
{
    public class GetProductsWithCategoryNameQueryRequest : IRequest<GetProductsWithCategoryNameQueryResponse>
    {
    }
}
