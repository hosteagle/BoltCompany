using BoltCompany.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Domain.DTOs
{
    public class ProductDto : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string CategoryTitle { get; set; }
        public Guid CategoryId { get; set; }
    }
}
