using CleanShop.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanShop.Infra.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(id => id.Id);
        builder.Property(name => name.Name).HasMaxLength(100).IsRequired();
        builder.HasData(
            new Category(1, "Escola"),
            new Category(2, "Eletrônicos"),
            new Category(3, "Acessórios")
        );
    }
}