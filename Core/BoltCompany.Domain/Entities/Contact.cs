using BoltCompany.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Domain.Entities
{
    public class Contact : Entity
    {
        public string ContactType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
