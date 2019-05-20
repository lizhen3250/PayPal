using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ShoppingCart2.Models;
using System.IO;
using ShoppingCart2.Services;

namespace ShoppingCart2.Controllers
{
    public class HomeController : Controller
    {
        private ShopCartService shopCartService;

        public List<ShopCart> listShopCart;
        public List<Product> listProduct;

        public HomeController()
        {
            this.listProduct = new List<Product>();
            this.shopCartService = new ShopCartService();
            this.listShopCart = new List<ShopCart>();

            this.listProduct.Add(new Product(123456789, "Amber Perfume", 60,
                "Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare",
                "/Content/images/img1.png"));
            this.listProduct.Add(new Product(223456789, "Must Perfume", 120,
                "Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare",
                "/Content/images/img2.png"));
            this.listProduct.Add(new Product(334567892, "Vintage Perfume", 140,
                "Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare",
                "/Content/images/img3.png"));
            this.listProduct.Add(new Product(412356789, "Rose Perfume", 80,
                "Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare",
                "/Content/images/img4.png"));
        }

        public ActionResult Index()
        {
            return View(this.listProduct);
        }

        [HttpGet]
        public ActionResult Detail(int productId)
        {
            Product product = this.listProduct.Find(p => p.ProductId == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult Detail(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var price = collection["Price"];
                    var id = collection["ProductId"];
                    var name = collection["Name"];

                    string filePath = Server.MapPath("~\\Content\\database\\shopCart.xml");
                    this.listShopCart = this.shopCartService.Read(filePath);

                    var quantity = 1;
                    foreach(var list in listShopCart)
                    {
                        if (list.ProductName == name)
                        {
                            quantity = list.Quantity + 1;
                        }
                    }

                    ShopCart shopCart = new ShopCart(Convert.ToInt32(id), name, quantity, Convert.ToDecimal(price));

                    this.shopCartService.Save(filePath, shopCart);
                    this.listShopCart = this.shopCartService.Read(filePath);
                }
            }
            catch
            {
                return View();
            }
            return View("ShopCart", this.listShopCart);
        }

        [HttpGet]
        public ActionResult ShopCart()
        {
            return View(this.listShopCart);
        }
    }
}