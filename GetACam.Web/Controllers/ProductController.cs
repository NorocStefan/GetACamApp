using GetACam.Data.Entities;
using GetACam.Service.Categories;
using GetACam.Service.Products;
using GetACam.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetACam.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        

        public IActionResult Products(int id)
        {
            var products = productService.ProductsOnCategory(id);
            return View(products);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productDtos = productService.GetProducts();

            var productViewModels = productDtos.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description, 
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                ImageThumbnailUrl = x.ImageThumbnailUrl,
                CategoryId = x.CategoryId
            });
            return View(productViewModels);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromForm] ProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newProduct);
            }
            var productDto = new ProductDto
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price,
                ImageUrl = newProduct.ImageUrl,
                ImageThumbnailUrl = newProduct.ImageThumbnailUrl,
                CategoryId = newProduct.CategoryId
            };
            productService.AddProduct(productDto);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = productService.GetProduct(id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productViewModel = new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                ImageThumbnailUrl = product.ImageThumbnailUrl,
                CategoryId = product.CategoryId
            };

            return View(productViewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit([FromForm] ProductViewModel newProductDetails)
        {
            var product = productService.GetProduct(newProductDetails.Id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            product.Name = newProductDetails.Name;
            product.Description = newProductDetails.Description;
            product.Price = newProductDetails.Price;
            product.ImageUrl = newProductDetails.ImageUrl;
            product.ImageThumbnailUrl = newProductDetails.ImageThumbnailUrl;
            product.CategoryId = newProductDetails.CategoryId;

            productService.UpdateProduct(product);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                ImageThumbnailUrl = product.ImageThumbnailUrl,
                CategoryId = product.CategoryId
            };

            return View(productViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                ImageThumbnailUrl = product.ImageThumbnailUrl,
                CategoryId = product.CategoryId
            };

            return View(productViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ConfirmDelete([FromForm] int id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
