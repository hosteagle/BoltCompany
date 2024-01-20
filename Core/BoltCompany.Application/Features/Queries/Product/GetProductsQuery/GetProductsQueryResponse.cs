using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Product.GetProductsQuery
{
    public class GetProductsQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.Product> Products { get; set; }

    }
}
