using DomainLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityTypeConfigurations
{
    public class Corner_CFG : Base_CFG<Corner>, IEntityTypeConfiguration<Corner>
    {
        public void Configure(EntityTypeBuilder<Corner> builder)
        {
            base.Congiure(builder);
        }
    }
}
