using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class StoreInvetoryViewModel
    {
        [Display(Name = "Invetory ID" )]
        public int InvId { get; set; }

        [Display(Name = "Product ID")]
        public int InvProdId { get; set; }

        [Display(Name = "Store ID")]
        public int InvStoreLoc { get; set; }

        [Display(Name = "Inventory")]
        public int InvProdInventory { get; set; }
    }
}
