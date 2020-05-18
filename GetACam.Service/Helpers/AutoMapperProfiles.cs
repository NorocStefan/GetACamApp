using AutoMapper;
using GetACam.Data.Entities;
using GetACam.Service.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetACam.Service.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
