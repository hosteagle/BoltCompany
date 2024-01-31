using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPagesQuery
{
    public class GetExtraPagesQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.ExtraPage> ExtraPages { get; set; }
    }
}
