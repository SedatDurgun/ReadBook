using ApplicationLayer.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
         var books= await _bookService.GetAllBooksAsync();
            return View(books);

        }

        public IActionResult Privacy()
        {
            return View();
        }


















         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
