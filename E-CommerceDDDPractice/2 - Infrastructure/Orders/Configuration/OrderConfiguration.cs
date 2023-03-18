using _1___Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2___Infrastructure.Orders.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey("ProductId", "UserId");
            builder.Property(order => order.RequiredQuantity).IsRequired();

            //builder.HasOne(order => order.Product)
            //      .WithMany()
            //      .HasForeignKey();
            //builder.HasOne(order => order.User)
            //       .WithMany()
            //       .HasForeignKey();
        }
    }
}
