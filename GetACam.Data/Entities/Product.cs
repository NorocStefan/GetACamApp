using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GetACam.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string ImageThumbnailUrl { get; set; }
        [Required]
        public bool InStock { get; set; }

        public OrderItem OrderItem { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
