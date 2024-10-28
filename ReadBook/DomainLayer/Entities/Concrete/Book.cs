using DomainLayer.Entities.Abstract;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class Book : IEntity
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public string BookSummary { get; set; }
        public string BookPicture { get; set; }
        public string AuthorName { get; set; }
        public int CategoryID { get; set; }



        //RELATIONAL PROPERTY

        public Category Category { get; set; }
        public ICollection<Corner> Corners { get; set; }
        //ENUMS
        public DateTime AddTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public IsRegistered IsRegistered { get; set; }
        
      

    }
}
