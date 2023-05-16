using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Contacts.Persistence;
using Sales.Persistence.DbContext;
using Sales.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence;
public static class PersistencecServiceRegistration
{
    public static IServiceCollection
    AddPersistenceService
    (
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<SalesDbContext>
        (
            options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SalesDbConnectionString"));
            }
        );

        //Add repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();

        return services;
    }
}