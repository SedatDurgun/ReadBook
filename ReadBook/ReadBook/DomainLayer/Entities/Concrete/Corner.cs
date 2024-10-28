using DomainLayer.Entities.Abstract;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class Corner : IEntity
    {
        public int CornerID { get; set; }

        public int BookID { get; set; }

        public int UserID { get; set; }

        public int piece { get; set; }

        //RELATIONAL PROPERTY 
        public User User { get; set; }
        public Book Book { get; set; }

        //ENUMS


        public DateTime AddTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public IsRegistered IsRegistered { get; set; }



        

    }
}
