using GetACam.Data;
using GetACam.Data.Entities;
using GetACam.Service.Categories.Dtos;
using GetACam.Service.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetACam.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;


        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;

        }

        public CategoryDto GetCategory(int id)
        {
            if (id < 1) throw new ArgumentException(nameof(id));

            var category = categoryRepository.GetById(id);

            if (category == null) return null;

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = category.Products
            };

            return categoryDto;
        }

        public List<CategoryDto> GetCategories()
        {
            var categories = categoryRepository.GetAll();

            var categoryDtos = new List<CategoryDto>();

            foreach (var category in categories)
            {
                var categoryDto = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Products = category.Products
                };
                categoryDtos.Add(categoryDto);
            }
            return categoryDtos;
        }

    }
}

