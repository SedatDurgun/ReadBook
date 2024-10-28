using ApplicationLayer.Models.DTO_s;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       public  async Task<LoginResultDTO> LoginAsync(LoginDTO loginDTO)
        {
            LoginResultDTO result = new LoginResultDTO()
            {
                IsManager = false,
                IsUser = false,
                HasUser = false,
            };

            User? user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                return result;
            }
            if (await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                result.IsUser = true;
                result.HasUser = true;


                result.IsManager = await _userManager.IsInRoleAsync(user,"Manager");

                await _signInManager.SignInAsync(user,true);

            };
            return result;

        }

      public  async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

     public async Task<bool> NewUserAsync(NewUserDTO newUserDTO)
        {
           User user = new User();
            user.Name = newUserDTO.Name;
            user.LastName = newUserDTO.LastName;
            user.Adress = newUserDTO.Adress;
            user.UserName = newUserDTO.UserName;
            user.Email = newUserDTO.Email;

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash=passwordHasher.HashPassword(user,newUserDTO.Password);

            user.ConcurrencyStamp=Guid.NewGuid().ToString();
            user.SecurityStamp = Guid.NewGuid().ToString();
            
            var result = await _userManager.CreateAsync(user);

            //Sisteme uye olan, her yeni kullanıcı; "Uye" rolu ile olusturulur...
            await _userManager.AddToRoleAsync(user, "User");
        
            return result.Succeeded;

            

        }
    }
}
