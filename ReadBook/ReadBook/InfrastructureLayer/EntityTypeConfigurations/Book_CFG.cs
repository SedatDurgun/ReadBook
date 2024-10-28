using DomainLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.EntityTypeConfigurations
{
    public class Book_CFG : Base_CFG<Book>, IEntityTypeConfiguration<Book>
    {
       public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.BookName).HasColumnType("varchar").HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.BookSummary).HasColumnType("varchar").HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.BookPrice).HasColumnType("money").IsRequired(true);
            builder.Property(x=>  x.BookPicture).HasColumnType("varchar").HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.AuthorName).HasColumnType("varchar").HasMaxLength(50).IsRequired(true);

            base.Configure(builder);


        }
    }
}
