using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Category.GetCategoryByIdQuery
{
    public class GetCategoryByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.Category Category { get; set; }

    }
}
