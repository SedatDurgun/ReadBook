using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.ViewModels
{
    public class CornerVM
    {
        public int CornerID { get; set; }

        public int BookID { get; set; }

        public int UserID { get; set; }

        public string BookName { get; set; }
        public string BookSummary { get; set; }

        public int piece { get; set; }
    }
}
