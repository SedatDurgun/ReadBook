using DomainLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.EntityTypeConfigurations
{
    public class Category_CFG : Base_CFG<Category>, IEntityTypeConfiguration<Category>
    {
       public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).IsRequired(true).HasColumnType("varchar").HasMaxLength(50); 

            base.Configure(builder);

            builder.HasData(

                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Roman",
                    AddTime = DateTime.Now,
                    IsRegistered = DomainLayer.Enums.IsRegistered.Active,

                },

                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Bilim Kurgu",
                    AddTime = DateTime.Now,
                    IsRegistered = DomainLayer.Enums.IsRegistered.Active,
                });
                
                
                
                
                





        }
    }
}
