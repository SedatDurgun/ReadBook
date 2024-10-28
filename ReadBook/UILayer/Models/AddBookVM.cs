using System.ComponentModel.DataAnnotations;

namespace UILayer.Models
{
    public class AddBookVM
    {
        [Display(Name ="BookName")]
        public string BookName { get; set; }

        [Range(0,1000)]
        public decimal BookPrice { get; set; }
        public string BookSummary { get; set; }
        public  IFormFile? BookPicture { get; set; }
        public string AuthorName { get; set; }

        [Display(Name = "Category")]
        public string CategoryID { get; set; }
    }
}
