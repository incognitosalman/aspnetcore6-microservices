using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catelog.Infrastructure.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
