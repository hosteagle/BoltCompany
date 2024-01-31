using BoltCompany.Application.Repositories;
using BoltCompany.Domain.Entities;
using BoltCompany.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Persistence.Repositories
{
    public class PageDetailRepository : Repository<PageDetail>, IPageDetailRepository
    {
        public PageDetailRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
