using BoltCompany.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Domain.Entities
{
    public class ProductImage : Entity
    {
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public bool? IsCoverImage { get; set; }
        public Guid ProductId { get; set; }
    }
}
