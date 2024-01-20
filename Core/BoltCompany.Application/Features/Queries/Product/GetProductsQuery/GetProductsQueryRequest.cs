using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Product.GetProductsQuery
{
    public class GetProductsQueryRequest : IRequest<GetProductsQueryResponse>
    {
    }
}
