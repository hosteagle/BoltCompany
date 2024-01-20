using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Product.GetProductByIdQuery
{
    public class GetProductByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.Product Product { get; set; }

    }
}
