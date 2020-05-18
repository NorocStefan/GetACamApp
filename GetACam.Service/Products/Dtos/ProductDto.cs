﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GetACam.Service.Products
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool InStock { get; set; }

        public int CategoryId { get; set; }
    }
}
