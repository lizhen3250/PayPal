using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart2.Models
{
    public class TransactionDetail
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ShippingAddress { get; set; }

        public string CreatedTime { get; set; }

        public string RecipientName { get; set; }

        public TransactionDetail() { }
        public TransactionDetail(string id, string name, string shippingAddress, string createdTime, string recipientName)
        {
            this.Id = id;
            this.Name = name;
            this.ShippingAddress = shippingAddress;
            this.CreatedTime = createdTime;
            this.RecipientName = recipientName;
        }
    }
}