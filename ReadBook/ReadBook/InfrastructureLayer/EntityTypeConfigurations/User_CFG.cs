using DomainLayer.Entities.Abstract;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.EntityTypeConfigurations
{
    public class User_CFG : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x=>x.UserName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Adress).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            User user = new User()
            {
                Id = 1,
                Name = "Super",
                LastName="Admin",
                Adress="Ankara",
                UserName= "superAdmin",
                NormalizedUserName="SUPERADMIN," ,
                Email= "superadmin@deneme.com",
                NormalizedEmail="SUPERADMIN@DENEME.COM",
                SecurityStamp= Guid.NewGuid().ToString(),
                ConcurrencyStamp= Guid.NewGuid().ToString(),
                EmailConfirmed= false,

            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "superAdmin123");

            builder.HasData(user);
        }
    }
}











 