using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using ApplicationLayer.Services.CategoryService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace UILayer.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task <IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task <IActionResult> CreateCategory() 
        {
            ViewBag.Categories= new SelectList(await _categoryService.GetAllCategoriesAsync(),"CategoryID","CategoryName");
         return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                AddCategoryDTO addCategoryDTO = new AddCategoryDTO();

                // Eğer CategoryName null ise, yeni bir isim veriyoruz
                if (string.IsNullOrEmpty(categoryVM.CategoryName)) //MopdelState.Isvalid çalışmadığı için bu kodu yazıldı
                {
                    Guid guid = Guid.NewGuid();
                    addCategoryDTO.CategoryName = guid.ToString();
                }
                else
                {
                    addCategoryDTO.CategoryName = categoryVM.CategoryName;
                }

                await _categoryService.AddCategoryAsync(addCategoryDTO);
                return RedirectToAction("Index");
            }

            // Eğer ModelState geçerli değilse, formu ve hataları tekrar göster
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryID", "CategoryName");
            return View(categoryVM);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id) 
        {
            var category= await _categoryService.FindCategoryAsync(id);

            category.CategoryID = id;

            return View(category);
        
        }
        [HttpPost]
        public async Task <IActionResult> UpdateCategory(CategoryVM categoryVM) 
        {
            if (ModelState.IsValid)
            {
                UpdateCategoryDTO updateCategoryDTO = new UpdateCategoryDTO();
                updateCategoryDTO.CategoryID= (int) categoryVM.CategoryID;
                updateCategoryDTO.CategoryName= categoryVM.CategoryName;

                await _categoryService.UpdateCategoryAsync(updateCategoryDTO);

                return RedirectToAction("Index");
            }
            return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id) 
        { 
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        
        }
    }  


}
