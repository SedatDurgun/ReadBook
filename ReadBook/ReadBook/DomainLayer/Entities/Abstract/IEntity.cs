﻿using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Abstract
{
    public interface IEntity
    {
        public DateTime AddTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public DateTime? DeleteTime { get; set; }


        public IsRegistered IsRegistered { get; set; }
    }
}