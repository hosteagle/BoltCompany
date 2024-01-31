using BoltCompany.Application.Features.Base;
using BoltCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Contact.GetContactByIdQuery
{
    public class GetContactByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.Contact Contact { get; set; }
    }
}
