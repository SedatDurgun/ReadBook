using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityTypeConfigurations
{
    public class User_CFG : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Adress).IsRequired(false).HasColumnType("varchar").HasMaxLength(50);

            User user = new User()
            {
                Id = 1,
                Name="super",
                LastName="admin",
                Adress="Ankara",
                UserName="superAdmin",
                NormalizedUserName="SUPERADMIN",
                Email="superadmin@deneme.com",
                NormalizedEmail="SUPERADMIN@DENEME.COM",
                SecurityStamp= Guid.NewGuid().ToString(),
                ConcurrencyStamp= Guid.NewGuid().ToString(),
                EmailConfirmed=false,
            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "superadmin_123");
            builder.HasData(user);


        }

        
    }
}
