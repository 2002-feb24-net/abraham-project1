using Microsoft.AspNetCore.Mvc;
using Project1.Domain.Interface;
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

        public ActionResult Index(int id)
        {
            id = 1;
            var customer = Repo.GetCustomerById(id);
            CustomerViewModel viewModel = new CustomerViewModel()
            {
                CstmId = customer.CstmId,
            };
            return View(viewModel);
        }
    }
}
