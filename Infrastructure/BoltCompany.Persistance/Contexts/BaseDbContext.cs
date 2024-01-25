using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using BoltCompany.Domain.Entities;
using BoltCompany.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BoltCompany.Domain.Entities.Identity;

namespace BoltCompany.Persistence.Contexts
{
    public class BaseDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Logo> Logos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<Entity>();
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.Now.Date;
                        data.Entity.IsModified = true;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.Now.Date;
                        data.Entity.IsModified = false;
                        break;
                }

            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


    }
}
