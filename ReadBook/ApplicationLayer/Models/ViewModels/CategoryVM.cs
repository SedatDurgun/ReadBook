using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.ViewModels
{
    public class CategoryVM
    {
        public int? CategoryID { get; set; } //Zorunlu değil
        public string CategoryName { get; set; }
    }
}
