using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPageByIdQuery
{
    public class GetExtraPageByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.ExtraPage ExtraPage { get; set; }
    }
}
