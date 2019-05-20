using ShoppingCart2.Models;
using ShoppingCart2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart2.Controllers
{
    public class TransactionController : Controller
    {
        private TransactionService transactionService;
        private ShopCartService shopCartService;
        private List<TransactionDetail> listTransaction;

        public TransactionController()
        {
            this.transactionService = new TransactionService();
            this.listTransaction = new List<TransactionDetail>();
            this.shopCartService = new ShopCartService();
        }
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            string transactionId = Request.Params["transaction_id"];
            string name = Request.Params["name"];
            string address = Request.Params["address"];
            string createdTime = Request.Params["created_time"];
            string recipientName = Request.Params["recipient_name"];

            TransactionDetail transaction = new TransactionDetail(transactionId, name, address, createdTime, recipientName);

            string filePath = Server.MapPath("~\\Content\\database\\TransactionDetail.xml");

            //clear shopping cart page
            string shoppingFilePath = Server.MapPath("~\\Content\\database\\ShopCart.xml");

            this.shopCartService.Delete(shoppingFilePath);

            this.transactionService.Save(filePath, transaction);

            return View(transaction);
        }

        public ActionResult ShowAllTransaction()
        {
            string filePath = Server.MapPath("~\\Content\\database\\TransactionDetail.xml");

            this.listTransaction = this.transactionService.Read(filePath);

            return View(this.listTransaction);
        }
    }
}