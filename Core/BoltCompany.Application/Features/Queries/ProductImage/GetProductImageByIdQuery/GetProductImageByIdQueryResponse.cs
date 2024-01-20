using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ProductImage.GetProductImageByIdQuery
{
    public class GetProductImageByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.ProductImage ProductImage { get; set; }
    }
}
