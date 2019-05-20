using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart2.Models
{
    public class Product
    {
        public Product(int productId, string name, decimal price, string description, string imageUrl)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.ImageUrl = imageUrl;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

    }
}