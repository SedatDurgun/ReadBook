using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.DTO_s
{
    public class NewUserDTO
    {
      
        public string Name { get; set; }
        
        public string LastName { get; set; }
              
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       
        public string RepeatPassword { get; set; }
        
        public string Adress { get; set; }
    }
}
