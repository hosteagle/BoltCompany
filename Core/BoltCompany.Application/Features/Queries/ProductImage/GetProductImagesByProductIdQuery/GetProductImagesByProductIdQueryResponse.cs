using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ProductImage.GetProductImagesByProductIdQuery
{
    public class GetProductImagesByProductIdQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.ProductImage> ProductImages { get; set; }
    }
}
