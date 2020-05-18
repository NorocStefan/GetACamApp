using GetACam.Data;
using GetACam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using GetACam.Service.Categories;
using AutoMapper;

namespace GetACam.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly GetACamContext getACamContext;
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public ProductService(GetACamContext getACamContext, IRepository<Product> productRepository, IUnitOfWork unitOfWork, ICategoryService categoryService, IMapper mapper)  
        {
            this.getACamContext = getACamContext;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return getACamContext.Products.Include(c => c.Category);
            }
        }

        public List<ProductDto> ProductsOnCategory(int id)
        {
            var products = GetProducts();
            var categories = categoryService.GetCategories();

            var productInCategory = products.Where(p => p.CategoryId == id).ToList();  

            return productInCategory;

        }

        public ProductDto GetProduct(int id)
        {
            if (id < 1) throw new ArgumentException(nameof(id));

            var product = productRepository.GetById(id);

            if (product == null) return null;

            var productToReturn = mapper.Map<ProductDto>(product);
            //var productDto = new ProductDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    ImageUrl = product.ImageUrl,
            //    ImageThumbnailUrl = product.ImageThumbnailUrl,
            //    CategoryId = product.CategoryId
            //};

            return productToReturn;
        }

        public List<ProductDto> GetProducts()
        {
            var products = productRepository.GetAll();

            var productDtos = new List<ProductDto>();

            var productsToReturn = mapper.Map<List<ProductDto>>(products);

            //foreach (var product in products)
            //{
            //    var productDto = new ProductDto
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Description = product.Description,
            //        Price = product.Price,
            //        ImageUrl = product.ImageUrl,
            //        ImageThumbnailUrl = product.ImageThumbnailUrl,
            //        CategoryId = product.CategoryId
            //    };
            //    productDtos.Add(productDto);
            //}
            return productsToReturn;
        }

        public void AddProduct(ProductDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));

            var product = mapper.Map<Product>(productDto);

            //var product = new Product
            //{
            //    Name = productDto.Name,
            //    Description = productDto.Description,
            //    Price = productDto.Price,
            //    ImageUrl = productDto.ImageUrl,
            //    ImageThumbnailUrl = productDto.ImageThumbnailUrl,
            //    CategoryId = productDto.CategoryId
            //};

            productRepository.Add(product);
            unitOfWork.Commit();
        }

        public void UpdateProduct(ProductDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));

            var product = productRepository.GetById(productDto.Id);

            if (product == null) throw new Exception($"Brand with ID = {productDto.Id} was not found!");

            var products = mapper.Map<Product>(productDto);

            //product.Name = productDto.Name;
            //product.Description = productDto.Description;
            //product.Price = productDto.Price;
            //product.ImageUrl = productDto.ImageUrl;
            //product.ImageThumbnailUrl = productDto.ImageThumbnailUrl;
            //product.CategoryId = productDto.CategoryId;

            productRepository.Update(products);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            if (id < 1) throw new ArgumentException(nameof(id));

            var product = productRepository.GetById(id);

            if (product == null) throw new Exception($"Product with ID = {id} was not found");

            productRepository.Delete(product);
            unitOfWork.Commit();
        }

    }
}
