using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetACam.Service.Categories;
using GetACam.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetACam.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var categoryDto = categoryService.GetCategories();

            var categoryViewModels = categoryDto.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Products = x.Products
            });
            return View(categoryViewModels);
        }
    }
}
