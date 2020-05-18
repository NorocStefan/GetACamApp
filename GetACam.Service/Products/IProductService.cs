using GetACam.Data;
using GetACam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetACam.Service.Products
{
    public interface IProductService
    {
        IEnumerable<Product> AllProducts { get; }
        void AddProduct(ProductDto productDto);
        void Delete(int id);
        ProductDto GetProduct(int id);
        List<ProductDto> GetProducts();
        List<ProductDto> ProductsOnCategory(int id);
        void UpdateProduct(ProductDto productDto);
    }
}
