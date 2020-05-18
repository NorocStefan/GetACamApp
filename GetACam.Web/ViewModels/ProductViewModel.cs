using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetACam.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public int CategoryId { get; set; }

    }
}
