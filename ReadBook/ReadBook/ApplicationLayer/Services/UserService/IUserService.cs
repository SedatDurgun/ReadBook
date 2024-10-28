using ApplicationLayer.Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.UserService
{
    public interface IUserService
    {
        Task<bool> NewUserAsync(NewUserDTO newUserDTO);

        Task<LoginResultDTO> LoginAsync(LoginDTO loginDTO);

        Task LogOutAsync();

    }
}
