using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class ProductOrderViewModel
    {
        [Display(Name = "Order ID:")]
        public int OrderId { get; set; }

        [Display(Name = "Customer ID:")]
        public int OrderCstmId { get; set; }

        [Display(Name = "Store ID:")]
        public int? OrderStrId { get; set; }

        [Display(Name = "Order Date:")]
        public DateTime? OrderOrdDate { get; set; }

        public List<OrderList> OrderLists { get; set; }

        public List<Customer> Customers { get; set; }

        public List<StoreLocation> StoreLocations { get; set; }
    }
}
