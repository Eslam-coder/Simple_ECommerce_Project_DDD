using _1___Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2___Infrastructure.Products.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Name).IsRequired();
            builder.Property(prodcut => prodcut.Quantity).IsRequired();
            builder.Property(prodcut => prodcut.Price).IsRequired();
            builder.Property(prodcut => prodcut.Description).HasMaxLength(int.MaxValue);

            //Relation bet product and category ( M to 1)
            //builder.HasOne(product => product.Category)
            //       .WithMany()
            //       .HasForeignKey("CategoryId")
            //       .OnDelete(DeleteBehavior.Cascade);

            //Relation bet product and user ( M to M)
            //this line is using when we want third table automatic
            //without inialize order table
            //builder.HasMany(product => product.Users);
        }
    }
}
