using CleanArchitecture.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(id => id.Id);
            builder.Property(name => name.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new Category(1, "Software"), new Category(2, "Devices"), new Category(3, "Courses"));
        }
    }
}