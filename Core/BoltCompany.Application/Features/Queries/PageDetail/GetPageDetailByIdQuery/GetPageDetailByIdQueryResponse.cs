using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailByIdQuery
{
    public class GetPageDetailByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.PageDetail PageDetail { get; set; }
    }
}
