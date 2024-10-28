
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Adress { get; set; }

        //RELATIONAL PROPERTY

        public ICollection<Corner> Corners { get; set; }



    }

   
}
