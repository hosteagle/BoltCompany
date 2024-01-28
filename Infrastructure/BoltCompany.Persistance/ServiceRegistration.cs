using BoltCompany.Application.Repositories;
using BoltCompany.Domain.Entities.Identity;
using BoltCompany.Persistence.Contexts;
using BoltCompany.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BaseDbContext>();

            services.AddTransient<IAboutRepository, AboutRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<ILogoRepository, LogoRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();

            return services;
        }
    }
}
