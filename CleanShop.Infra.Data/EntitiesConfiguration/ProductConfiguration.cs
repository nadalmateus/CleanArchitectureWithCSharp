using CleanShop.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanShop.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(id => id.Id);
        builder.Property(name => name.Name).HasMaxLength(100).IsRequired();
        builder.Property(description => description.Description).HasMaxLength(200).IsRequired();
        builder.Property(price => price.Price).HasPrecision(10, 2);
        builder.HasOne(category => category.Category).WithMany(products => products.Products)
            .HasForeignKey(categoryId => categoryId.CategoryId);
    }
}