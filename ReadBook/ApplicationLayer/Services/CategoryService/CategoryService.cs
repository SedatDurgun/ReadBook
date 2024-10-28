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

namespace ApplicationLayer.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategoryAsync(AddCategoryDTO addCategoryDTO)
        {
            Category category = new Category();

            _mapper.Map(addCategoryDTO,category);

            await _categoryRepository.AddAsync(category);
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
             return _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryVM> FindCategoryAsync(int id)
        {
            Category category = await _categoryRepository.FindAsync(id);
            CategoryVM findCategory  = new CategoryVM();
            _mapper.Map(category, findCategory);

            return findCategory;
           
        }

        public async Task<IEnumerable<CategoryVM>> GetAllCategoriesAsync()
        {
            List<Category> categories = _categoryRepository.GetAllActiveAsync().Result.ToList();
            List<CategoryVM> result = new List<CategoryVM>();
            _mapper.Map(categories, result);

            return result;
        }

        public async Task<List<CategoryDTO>> ShowAllCategoriesAsync()
        {
           var categories= await _categoryRepository.GetAllActiveAsync();

            List<CategoryDTO> _categories = new List<CategoryDTO>();

            _mapper.Map(_categories, categories);

            return _categories;

        }
      

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
           Category category = new Category();
            _mapper.Map(updateCategoryDTO, category);

            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
