using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.ViewModels
{
    public class BookVM
    {
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public string BookSummary { get; set; }
        public string BookPicture { get; set; }
        public string AuthorName { get; set; }
        
    }
}
