using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailsQuery
{
    public class GetPageDetailsQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.PageDetail> PageDetails { get; set; }
    }
}
