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
    public class CustomerController : Controller
    {
        public IProject1Repository Repo { get; }

        public CustomerController(IProject1Repository repo) =>
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
                        CstmDefaultLocation = customer.CstmDefaultStoreLocation
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

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer
                    {
                        CstmFirstName = viewModel.CstmFirstName,
                        CstmLastName = viewModel.CstmLastName,
                        CstmEmail = viewModel.CstmEmail
                    };
                    Repo.AddCustomer(customer);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}
