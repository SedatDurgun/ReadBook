using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.CornerService
{
    public interface ICornerService
    {
        Task AddBookCornerAsync(AddCornerDTO addCornerDTO);

        Task DeleteBookCornerAsync(int id);

        IEnumerable<CornerVM> GetAllCornersAsync();
    }
}
