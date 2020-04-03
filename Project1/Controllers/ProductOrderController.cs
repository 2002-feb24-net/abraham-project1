using Microsoft.AspNetCore.Mvc;
using Project1.Domain.Interface;
using Project1.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Controllers
{
    public class ProductOrderController : Controller
    {
        public IProject1Repository Repo { get; }

        public ProductOrderController(IProject1Repository repo) =>
            Repo = repo ?? throw new ArgumentException(nameof(repo));

        public ActionResult Index(string search = "")
        {
            CustomerViewModel viewModel = new CustomerViewModel();
            if (search != "")
            {
                ViewBag.Search = search;
                var customer = Repo.GetCustomerById(search);
                if (customer != null)
                {
                    viewModel = new CustomerViewModel()
                    {
                        CstmId = customer.CstmId,
                        CstmFirstName = customer.CstmFirstName,
                        CstmLastName = customer.CstmLastName,
                        CstmEmail = customer.CstmEmail,
                        CstmDefaultLocation = customer.CstmDefaultStoreLocation,
                        ProductOrders = customer.ProductOrder
                    };
                }
                else
                {
                    viewModel = new CustomerViewModel()
                    {
                        CstmId = -1
                    };
                }
            }
            return View(viewModel);
        }

        public ActionResult OrderDetails(int OrderId)
        {
            var order = Repo.GetOrderById(OrderId);

            var orders = Repo.GetCustomerHistory(OrderId);
            
            var viewModel = new ProductOrderViewModel
            {
                OrderId = order.OrderId,
                OrderCstmId = order.OrderCstmId,
                OrderStrId = order.OrderStrId,
                OrderOrdDate = order.OrderOrdDate,
                OrderLists = order.OrderList
            };
            return View(viewModel);
        }

    }
}
