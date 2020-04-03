using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class OrderListViewModel
    {
        [Display(Name = "Order List ID")]
        public int LstId { get; set; }

        [Display(Name = "Order ID")]
        public int LstOrderId { get; set; }

        [Display(Name = "Product ID")]
        public int LstProdId { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }

        public List<Product> Products { get; set; }
    }
}
