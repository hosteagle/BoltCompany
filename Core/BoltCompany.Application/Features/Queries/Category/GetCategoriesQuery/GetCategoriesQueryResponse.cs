using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Category.GetCategoriesQuery
{
    public class GetCategoriesQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.Category> Categories { get; set; }

    }
}
