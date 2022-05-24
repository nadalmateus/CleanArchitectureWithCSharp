using CleanArchitecture.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(id => id.Id);
            builder.Property(name => name.Name).HasMaxLength(100).IsRequired();
            builder.Property(description => description.Description).HasMaxLength(100).IsRequired();
            builder.Property(price => price.Price).HasMaxLength(100).IsRequired();
            builder.HasOne(category => category.Category).WithMany(product => product.Products).HasForeignKey(categoryId => categoryId.CategoryId);
        }
    }
}