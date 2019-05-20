using ShoppingCart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace ShoppingCart2.Services
{
    public class ShopCartService
    {
        private List<ShopCart> listShopCart;

        public ShopCartService()
        {
            this.listShopCart = new List<ShopCart>();
        }
        public void Save(string filePath, ShopCart shopCart)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNode memberlist = xmlDoc.SelectSingleNode("ShopCart");
            if (shopCart.Quantity > 1)
            {
                XmlNodeList xnl = memberlist.ChildNodes;
                foreach (XmlNode xn1 in xnl)
                {
                    XmlElement xe = (XmlElement)xn1;
                    if (xe.GetAttribute("name") == shopCart.ProductName)
                    {
                        xe.SetAttribute("quantity", shopCart.Quantity.ToString());
                    }
                }
            }
            else
            {
                XmlElement member = xmlDoc.CreateElement("Product");
                member.SetAttribute("id", shopCart.Id.ToString());
                member.SetAttribute("name", shopCart.ProductName);
                member.SetAttribute("price", shopCart.Price.ToString());
                member.SetAttribute("quantity", shopCart.Quantity.ToString());
                memberlist.AppendChild(member);
            }

            xmlDoc.Save(filePath);
        }

        public List<ShopCart> Read(string filePath)
        {
            this.listShopCart = new List<ShopCart>();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNode xn = xml.SelectSingleNode("ShopCart");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
                ShopCart shopCart = new ShopCart();
                XmlElement xe = (XmlElement)xn1;
                shopCart.Id = Convert.ToInt32(xe.GetAttribute("id"));
                shopCart.ProductName = xe.GetAttribute("name");
                shopCart.Price = Convert.ToDecimal(xe.GetAttribute("price"));
                shopCart.Quantity = Convert.ToInt32(xe.GetAttribute("quantity"));
                this.listShopCart.Add(shopCart);
            }
            return this.listShopCart;
        }

        public void Delete(string filePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNode root = xml.DocumentElement;
            root.RemoveAll();
            xml.Save(filePath);
        }
    }
}