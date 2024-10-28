using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<CategoryVM> FindCategoryAsync(int id);

        Task AddCategoryAsync(AddCategoryDTO addCategoryDTO);

        Task<bool> DeleteCategoryAsync(int id);

        Task<IEnumerable<CategoryVM>> GetAllCategoriesAsync();
        Task<List<CategoryDTO>> ShowAllCategoriesAsync();

        Task<UpdateCategoryDTO> UpdateCategoryAsync(int id);


    }
}
