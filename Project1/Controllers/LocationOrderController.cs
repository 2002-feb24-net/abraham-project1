using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Domain.Interface;
using Project1.Domain.Model;
using Project1.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Controllers
{
    public class LocationOrderController : Controller
    {
        public IProject1Repository Repo { get; }

        public LocationOrderController(IProject1Repository repo) =>
            Repo = repo ?? throw new ArgumentException(nameof(repo));

        public ActionResult Index(LinkViewModel lVM)
        {
            List<SelectListItem> selectListLoc = new List<SelectListItem>();
            var storeLoc = Repo.GetStoreLocations();
            var viewModel = new LinkViewModel();
            if (lVM.SelectedLocation != null)
            {
                int? id = lVM.SelectedLocation;
                var productOrder = Repo.GetStoreProductOrder(id);
                List<ProductOrder> products = new List<ProductOrder>();
                foreach(var p in productOrder.ProductOrder)
                {
                    products.Add(p);
                }
                string fullName = "";
                var customer = Repo.GetCustomerByFullName(fullName);

                viewModel = new LinkViewModel()
                {
                    StoreLocationViewModel = new StoreLocationViewModel()
                    {
                        LocId = productOrder.LocId,
                        LocStreet = productOrder.LocStreet,
                        LocCity = productOrder.LocCity,
                        LocCountry = productOrder.LocCountry
                    },
                    SelectedLocation = id,
                    productOrders = products
                };
            }
            else
            {
                foreach (var li in storeLoc)
                {
                    selectListLoc.Add(new SelectListItem { Text = li.LocCity, Value = li.LocId.ToString() });
                }

                viewModel = new LinkViewModel()
                {
                    LocationList = selectListLoc
                };
            }
            return View(viewModel);
        }
    }
}
