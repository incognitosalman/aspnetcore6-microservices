using Catalog.Application.Contracts.Persistence;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CatalogConnection"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            return services;
        }
    }
}
