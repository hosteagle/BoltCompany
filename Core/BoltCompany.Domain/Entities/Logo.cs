using BoltCompany.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Domain.Entities
{
    public class Logo : Entity
    {
        public string LogoUrl { get; set; }
        public string LogoName { get; set; }
        public string IconUrl { get; set; }
        public string IconName { get; set; }
    }
}
