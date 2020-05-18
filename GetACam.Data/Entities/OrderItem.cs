﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GetACam.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public string ShoppingCartId { get; set; }


    }
}
