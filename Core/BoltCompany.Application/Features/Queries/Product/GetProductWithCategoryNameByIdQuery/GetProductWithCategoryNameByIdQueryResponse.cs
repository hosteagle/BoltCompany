using BoltCompany.Application.Features.Base;
using BoltCompany.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Product.GetProductWithCategoryNameByIdQuery
{
    public class GetProductWithCategoryNameByIdQueryResponse : BaseResponse
    {
        public ProductDto ProductWithCategoryName { get; set; }

    }
}
