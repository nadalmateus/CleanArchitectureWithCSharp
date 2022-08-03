using CleanShop.Domain.Interfaces;
using CleanShop.Infra.Data.Context;
using CleanShop.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanShop.Infra.IoC;

public static class DependenceInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(optons => optons.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            migrations => migrations.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}