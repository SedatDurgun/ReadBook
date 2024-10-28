using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Services.CornerService;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class UserController : Controller
    {
        private readonly ICornerService _cornerService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(ICornerService cornerService, UserManager<User> userManager, IMapper mapper)
        {
            _cornerService = cornerService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cornerBooks =  _cornerService.GetAllCornersAsync();
            return View(cornerBooks);
        }

        public async Task <IActionResult> AddCorner(int id) 
        {
            AddCornerDTO addCornerDTO = new AddCornerDTO();
            addCornerDTO.UserID = GetUserID();
            addCornerDTO.BookID = id;
            addCornerDTO.piece = 1;

            await _cornerService.AddBookCornerAsync(addCornerDTO);

            return Redirect("~/Home/Index");
        }

        public int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }
    }
}
