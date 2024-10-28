using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddBookAsync(AddBookDTO addBookDTO)
        {
            Book  book = new Book();

            _mapper.Map(addBookDTO,book);
            await _repository.AddAsync(book);
        }
        public async Task<UpdateBookDTO> UpdateBookAsync(int id) // 
        {
            Book book = await _repository.FindAsync(id);

            UpdateBookDTO updateBookDTO = new UpdateBookDTO();

            _mapper.Map(updateBookDTO,book);

            return updateBookDTO;
            

        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<BookVM> FindBookAsync(int id)
        {
           Book book =await _repository.FindAsync(id);

           BookVM bookVM = new BookVM();

            _mapper.Map(book,bookVM);
            return bookVM;
             

        }

        public async Task<IEnumerable<BookVM>> GetAllBooksAsync()
        {
           List<Book> books = _repository.GetAllActiveAsync().Result.ToList();
            List<BookVM> bookVMs = new List<BookVM>();
            _mapper.Map(books, bookVMs);
            return bookVMs;
        }

        public async Task<bool> LetUpdateBookAsync(UpdateBookDTO updateBookDTO) // Books that havee been updatedd
        {
            Book book = new Book();
            _mapper.Map(updateBookDTO,book);

            return await _repository.UpdateAsync(book);
        }

        public async Task<IEnumerable<BookVM>> ShowCategoryAsync(int categoryId)
        {
           List<Book> books= _repository.GetAllActiveAsync().Result.Where(x=>x.CategoryID==categoryId).ToList();
            List<BookVM> bookVMs= new List<BookVM>();
            _mapper.Map(books,bookVMs);

            return bookVMs;
        }

       
    }
}
