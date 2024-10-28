using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Services.BookService;
using ApplicationLayer.Services.CategoryService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UILayer.Models;

namespace UILayer.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class BookController : Controller
    {
       private readonly IBookService _bookService;
       private readonly ICategoryService _categoryService;
       private readonly IMapper _mapper;

        public BookController(IBookService bookService, ICategoryService categoryService, IMapper mapper)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var getbooks= await _bookService.GetAllBooksAsync();

            return View(getbooks);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBook() 
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(),"CategoryID","CategoryName");

            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateBook(AddBookVM addBookVM) //FOREIGN Hatsından dolyı database CategoryID Foreign Key null hale getirildi süre kaynaklı olarak kesin çözüm yapılamadı  proje bitiminde tekrar bakılacak. 
        {

            if (ModelState.IsValid) 
            {
               AddBookDTO addBookDTO = new AddBookDTO();


                addBookDTO.BookName= addBookVM.BookName;
                addBookDTO.AuthorName= addBookVM.AuthorName;
                addBookDTO.BookSummary= addBookVM.BookSummary;
                addBookDTO.BookPrice= addBookVM.BookPrice;


                Guid guid = Guid.NewGuid();
                if (addBookVM.BookPicture != null)
                {
                    string picture = guid.ToString() + addBookVM.BookPicture.FileName;
                    FileStream stream = new FileStream("wwwroot/BookPictures/" + picture, FileMode.CreateNew);


                    await addBookVM.BookPicture.CopyToAsync(stream);
                    addBookDTO.BookPicture = picture;
                    stream.Close();
                }
                else 
                {
                    addBookDTO.BookPicture = "Empty.jpg";
                }

                await _bookService.AddBookAsync(addBookDTO);
                return RedirectToAction("Index");

            }

            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryID", "CategoryName");
            return View();

        }
        [HttpGet]
        public async Task <IActionResult> UpdateBook(int id)
        {
            var book = await _bookService.UpdateBookAsync(id);

            var categoies =await _categoryService.GetAllCategoriesAsync();

             ViewBag.Categories = new SelectList(categoies,"CategoryID","CategoryName",book.CategoryID);

            return View(book);
        }
        [HttpPost]
        public async Task <IActionResult> UpdateBook(UpdateBookDTO updateBookDTO)
        {
            if (ModelState.IsValid) 
            {
                await _bookService.LetUpdateBookAsync(updateBookDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryID", "CategoryName");

            return View();
        } 

        [HttpPost]
        public async Task <IActionResult> DeleteBook(int id) 
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction("Index");
        }
    }
}
