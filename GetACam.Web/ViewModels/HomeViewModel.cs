using GetACam.Data.Entities;
using GetACam.Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetACam.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ProductDto> ProductsOfTheWeek { get; set; }
    }
}
