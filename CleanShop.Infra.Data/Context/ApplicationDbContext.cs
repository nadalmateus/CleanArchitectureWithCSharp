using CleanShop.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}


//To add migrations use: dotnet ef migrations add MigrationName -s .\CleanShop.WebUI\ -p .\CleanShop.Infra.Data\
//To update data base use: dotnet ef database update -s .\CleanShop.WebUI\ -p .\CleanShop.Infra.Data\