using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class StoreLocationViewModel
    {
        [Display(Name = "Location ID")]
        public int LocId { get; set; }

        [Display(Name = "Street Address")]
        public string LocStreet { get; set; }

        [Display(Name = "City")]
        public string LocCity { get; set; }

        [Display(Name = "Country")]
        public string LocCountry { get; set; }
    }
}
