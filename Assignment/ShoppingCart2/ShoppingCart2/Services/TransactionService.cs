using ShoppingCart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace ShoppingCart2.Services
{
    public class TransactionService
    {
        private List<TransactionDetail> listTransaction;
        public TransactionService()
        {
            this.listTransaction = new List<TransactionDetail>();
        }
        public void Save(string filePath, TransactionDetail transaction)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(filePath);
            XmlNode memberlist = xmlDoc.SelectSingleNode("TransactionDetail");
            XmlElement member = xmlDoc.CreateElement("Transaction");
            member.SetAttribute("id", transaction.Id.ToString());
            member.SetAttribute("name", transaction.Name);
            member.SetAttribute("shippingAddress", transaction.ShippingAddress);
            member.SetAttribute("createdTime", transaction.CreatedTime);
            member.SetAttribute("recipientName", transaction.RecipientName);
            memberlist.AppendChild(member);
            xmlDoc.Save(filePath);
        }

        public List<TransactionDetail> Read(string filePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNode xn = xml.SelectSingleNode("TransactionDetail");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
                TransactionDetail transaction = new TransactionDetail();
                XmlElement xe = (XmlElement)xn1;
                transaction.Id = xe.GetAttribute("id");
                transaction.Name = xe.GetAttribute("name");
                transaction.ShippingAddress = xe.GetAttribute("shippingAddress");
                transaction.CreatedTime = xe.GetAttribute("createdTime");
                transaction.RecipientName = xe.GetAttribute("recipientName");
                this.listTransaction.Add(transaction);
            }
            return this.listTransaction;
        }
    }
}