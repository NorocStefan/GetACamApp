using System;
using System.Collections.Generic;
using System.Linq;
using GetACam.Data.Entities;
using GetACam.Service.Products;
using GetACam.Web.Models;
using GetACam.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GetACam.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService productService;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(IProductService productService, ShoppingCart shoppingCart)
        {
            this.productService = productService;
            this.shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = shoppingCart.GetOrderItems();
            shoppingCart.OrderItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = productService.AllProducts.FirstOrDefault(p => p.Id == productId);

            if (selectedProduct != null)
            {
                shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = productService.AllProducts.FirstOrDefault(p => p.Id == productId);

            if (selectedProduct != null)
            {
                shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }

    }
}