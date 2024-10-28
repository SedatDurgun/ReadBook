using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.BookService
{
    public interface IBookService
    {
        Task<BookVM> FindBookAsync(int id);

        Task<UpdateBookDTO> UpdateBookAsync(int id);

        Task AddBookAsync(AddBookDTO addBookDTO);

        Task<bool> DeleteBookAsync(int id);

        Task<bool> LetUpdateBookAsync(UpdateBookDTO updateBookDTO);

        Task<IEnumerable<BookVM>> GetAllBooksAsync();

        Task<IEnumerable<BookVM>> ShowCategoryAsync(int categoryId);

    }
}
