using BoltCompany.Application.Features.Base;
using BoltCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.About.GetAboutsQuery
{
    public class GetAboutsQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.About> Abouts { get; set; }
    }
}
