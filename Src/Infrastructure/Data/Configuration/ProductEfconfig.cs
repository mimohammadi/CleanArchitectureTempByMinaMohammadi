using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configuration
{
    public class ProductEfconfig : IEntityTypeConfiguration<Core.Entities.Product.Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Core.Entities.Product.Product> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired();

            builder.HasQueryFilter(a => a.IsDeleted == false);
        }
    }
}
