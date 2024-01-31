using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Queries.Contact.GetContactsQuery
{
    public class GetContactsQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.Contact> Contacts { get; set; }
    }
}
