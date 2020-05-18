using GetACam.Data.Entities;
using GetACam.Service.Categories.Dtos;
using GetACam.Service.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetACam.Service.Categories
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();
        CategoryDto GetCategory(int id);
        //List<ProductDto> ProductsOnCategory(int id);
    }
}
