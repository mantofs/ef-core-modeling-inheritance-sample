using Infra.Data;
using Domain.DomainServices;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Orders.Services;
using Application.Orders.Contracts;

namespace Application
{
    public static class Bootstrap
    {
        public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnection = configuration.GetConnectionString(nameof(EFCoreDbContext));

            services.AddDbContext<EFCoreDbContext>(options =>
              options.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection))
                     .EnableSensitiveDataLogging());

            services.AddScoped<OrderRepository, OrderRepositoryImp>();

            services.AddScoped<OrderService, OrderServiceImp>();
        }
    }
}