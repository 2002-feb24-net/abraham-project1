using Microsoft.AspNetCore.Mvc;
using Project1.Domain.Interface;
using Project1.Domain.Model;
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
                var customer = Repo.GetCustomerByFullName(search);
                if (customer != null)
                {
                    TempData["fullName"] = customer.CstmFirstName + " " + customer.CstmLastName;
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
            var fullName = TempData["fullName"].ToString();
            var customer = Repo.GetCustomerByFullName(fullName);
            var prodOrder = Repo.GetProductOrder(customer.CstmId);
            var orderList = Repo.GetOrderList(prodOrder.OrderId);
            List<IEnumerable<Product>> products = new List<IEnumerable<Product>>();
            foreach(var p in orderList)
            {
                var prod = Repo.GetProduct(p.LstProdId);
                products.Add(prod);
            }

            var viewModel = new LinkViewModel
            {
                CustomerViewModel = new CustomerViewModel
                {
                    CstmId = customer.CstmId,
                    CstmFirstName = customer.CstmFirstName,
                    CstmLastName = customer.CstmLastName,
                    CstmEmail = customer.CstmEmail,
                    CstmDefaultLocation = customer.CstmDefaultStoreLocation
                },
                ProductOrderViewModel = new ProductOrderViewModel
                {
                    OrderId = prodOrder.OrderId,
                    OrderCstmId = prodOrder.OrderCstmId,
                    OrderStrId = prodOrder.OrderStrId,
                    OrderOrdDate = prodOrder.OrderOrdDate,
                    OrderLists = orderList.ToList(),
                    Products = products
                }
            };
            return View(viewModel);
        }

    }
}
