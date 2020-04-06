using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class LinkViewModel
    {
        public CustomerViewModel CustomerViewModel { get; set; }

        public ProductOrderViewModel ProductOrderViewModel { get; set; }

        public List<Product> productViewModels { get; set; } = new List<Product>();

        public List<StoreLocation> storeLocationViewModels { get; set; } = new List<StoreLocation>();

        [Display(Name = "Select Location")]
        public int[] SelectedLocation { get; set; } = new int[0];

        public IEnumerable<SelectListItem> LocationList { get; set; }

        [Display(Name = "Make Store Default?")]
        public bool MakeDefault { get; set; }

        [Display(Name = "Select Products")]
        public int[] SelectedProduct { get; set; }

        [Display(Name = "Product List")]
        public IEnumerable<SelectListItem> ProductList { get; set; }
    }
}
