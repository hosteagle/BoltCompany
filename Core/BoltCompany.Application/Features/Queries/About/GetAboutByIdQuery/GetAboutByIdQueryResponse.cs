using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery
{
    public class GetAboutByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.About About { get; set; }
    }
}
