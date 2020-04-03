using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Product ID")]
        public int ProdId { get; set; }

        [Display(Name = "Product Name")]
        public string ProdName { get; set; }

        [Display(Name = "Description")]
        public string ProdDescription { get; set; }

        [Display(Name = "Price")]
        public double ProdPrice { get; set; }
    }
}
