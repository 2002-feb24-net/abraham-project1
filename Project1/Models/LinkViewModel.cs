using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class LinkViewModel
    {
        public CustomerViewModel CustomerViewModel { get; set; }
        public OrderListViewModel OrderListViewModel { get; set; }
        public ProductOrderViewModel ProductOrderViewModel { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public StoreInvetoryViewModel StoreInvetoryViewModel { get; set; }
        public StoreLocationViewModel StoreLocationViewModel { get; set; }
    }
}
