using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catelog.Infrastructure.Configurations
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
