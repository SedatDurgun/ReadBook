using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using ApplicationLayer.Services.UserService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace UILayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService  _userService;
        private readonly IMapper _mapper;

        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginDTO)  //Hata Mesajını değiştir(Şifre veya e posta ise) ve _LoginPartial codla
        {
            var result= await _userService.LoginAsync(loginDTO);

            if (result.HasUser)
            {
                return RedirectToAction("Index", "Home");
            }
            
            ModelState.AddModelError("Hata", "Kullanıcı Adı veya Şifre Yanlış");

            return View();
            
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(NewUserVM newUser)
        {
            if (ModelState.IsValid)
            {
                NewUserDTO newUserDTO = new NewUserDTO();

                _mapper.Map(newUser, newUserDTO);

                await _userService.NewUserAsync(newUserDTO);
                return RedirectToAction("Login");

            }
            else
            { return View(); }
        }

        public async Task<IActionResult> Logout() 
        {
           await _userService.LogOutAsync();
            return RedirectToAction("~/Home/Index");
        }
    }
}
