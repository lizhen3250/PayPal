using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart2.Models
{
    public class ShopCart
    {
        public ShopCart() { }
        public ShopCart(int id, string productName, int quantity, decimal price)
        {
            this.Id = id;
            this.ProductName = productName;
            this.Quantity = quantity;
            this.Price = price;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}