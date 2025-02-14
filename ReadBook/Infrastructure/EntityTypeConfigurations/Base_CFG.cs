﻿using DomainLayer.Entities.Abstract;
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
    public abstract class Base_CFG<TEntity> where TEntity : class, IEntity
    {
        protected void Congiure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.AddTime).HasColumnType("smalldatetime").IsRequired(true);
            builder.Property(x => x.UpdateTime).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(x => x.DeleteTime).HasColumnType("smalldatetime").IsRequired(false);
        }

        
    }
}
