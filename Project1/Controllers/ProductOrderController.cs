using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Domain.Interface;
using Project1.Domain.Model;
using Project1.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ActionResult OrderDetails(int orderId)
        {
            var fullName = TempData["fullName"].ToString();
            var customer = Repo.GetCustomerByFullName(fullName);
            var prodOrder = Repo.GetProductOrder(orderId);
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

        public ActionResult AddOrder(string search = "")
        {
            if(TempData["fullName"] != null)
            {
                search = TempData["fullName"].ToString();
            }
            LinkViewModel viewModel = new LinkViewModel();
            if (search != "")
            {
                var customer = Repo.GetCustomerByFullName(search);
                var storeLoc = Repo.GetStoreLocations();
                var products = Repo.GetAllProducts();

                if (customer != null)
                {
                    List<SelectListItem> selectListLoc = new List<SelectListItem>();
                    List<SelectListItem> selectListProd = new List<SelectListItem>();

                    foreach(var pr in products)
                    {
                        string n = pr.ProdName;
                        string d = pr.ProdDescription;
                        string p = "$" + pr.ProdPrice.ToString("#.##");
                        SelectListItem selectListItem = new SelectListItem()
                        {
                            Text = n + " " + d + " " + p,
                            Value = pr.ProdId.ToString(),
                            Selected = false
                        };
                        selectListProd.Add(selectListItem);
                    }

                    foreach (var li in storeLoc)
                    {
                        selectListLoc.Add(new SelectListItem { Text = li.LocCity, Value = li.LocId.ToString() });
                    }

                    viewModel = new LinkViewModel
                    {
                        CustomerViewModel = new CustomerViewModel()
                        {
                            CstmId = customer.CstmId,
                            CstmFirstName = customer.CstmFirstName,
                            CstmLastName = customer.CstmLastName,
                            CstmEmail = customer.CstmEmail,
                            CstmDefaultLocation = customer.CstmDefaultStoreLocation
                        },
                        LocationList = selectListLoc,
                        MakeDefault = false,
                        ProductList = selectListProd
                    };
                return View(viewModel);
                }
            }
            return RedirectToAction("Index", "ProductOrder", TempData["Redirected"] = "Redirected");
        }

        [HttpPost]
        public ActionResult PostOrder(LinkViewModel linkViewModel)
        {
            LinkViewModel linkView = new LinkViewModel();
            if (linkViewModel == null)
            {
                return RedirectToAction("Index", "ProductOrder", TempData["Redirected"] = "Redirected");
            }
            else
            {
                if (linkViewModel.MakeDefault)
                {
                    string fullName = linkViewModel.CustomerViewModel.CstmFirstName + " " + linkViewModel.CustomerViewModel.CstmLastName;
                    var customer = Repo.GetCustomerByFullName(fullName);

                    var cstm = new Customer()
                    {
                        CstmId = linkViewModel.CustomerViewModel.CstmId,
                        CstmFirstName = linkViewModel.CustomerViewModel.CstmFirstName,
                        CstmLastName = linkViewModel.CustomerViewModel.CstmLastName,
                        CstmEmail = linkViewModel.CustomerViewModel.CstmEmail,
                        CstmDefaultStoreLocation = linkViewModel.SelectedLocation
                    };
                    Repo.UpdateCustomer(cstm);
                    Repo.Save();

                }
                var productOrder = new ProductOrder()
                {
                    OrderCstmId = linkViewModel.CustomerViewModel.CstmId,
                    OrderStrId = linkViewModel.SelectedLocation
                };
                Repo.AddProductOrder(productOrder);
                Repo.Save();
                var orderId = Repo.GetMaxProductOrderID();
                foreach(var item in linkViewModel.SelectedProduct)
                {
                    var orderList = new OrderList()
                    {
                        LstOrderId = orderId,
                        LstProdId = item
                    };
                    Repo.AddOrderList(orderList);
                    Repo.Save();
                }
                return View();
            }
        }
    }
}
