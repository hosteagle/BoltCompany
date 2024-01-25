using BoltCompany.Application.Features.Base;
using BoltCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Logo.GetLogosQuery
{
    public class GetLogosQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.Logo> Logos { get; set; }
    }
}
