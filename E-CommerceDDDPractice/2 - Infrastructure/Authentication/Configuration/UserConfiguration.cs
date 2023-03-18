using _1___Domain.Authentication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2___Infrastructure.Authentication.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Email).IsRequired();
            builder.Property(user => user.FirstName).IsRequired()
                                                    .HasMaxLength(int.MaxValue);
            builder.Property(user => user.LastName).IsRequired()
                                                    .HasMaxLength(int.MaxValue);
            builder.Property(user => user.PasswordHash).IsRequired();

            //Relation bet product and user ( M to M)
            //this line is using when we wnat third table automatic
            //without inialize order table
            //builder.HasMany(user => user.Products);

            //Convert Address (valueObject) to columns in user table
            builder.OwnsOne(user => user.Address, owned =>
            {
                owned.WithOwner();
                owned.Property(address => address.Address1).HasColumnType("nvarchar(255)");
                owned.Property(address => address.Address2).HasColumnType("nvarchar(255)");
                owned.Property(address => address.City).HasColumnType("nvarchar(255)");
                owned.Property(address => address.Country).HasColumnType("nvarchar(255)");
                owned.Property(address => address.Fax).HasColumnType("nvarchar(255)");
                owned.Property(address => address.PhoneNumber).HasColumnType("nvarchar(255)");
                owned.Property(address => address.ZipCode).HasColumnType("nvarchar(255)");
            });

            //Another method to Convert Address (valueObject) to columns in user table
            //builder.OwnsOne(user => user.Address, owner => owner.WithOwner());
        }
    }
}
