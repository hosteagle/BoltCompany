using BoltCompany.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Domain.Entities
{
    public class About : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
