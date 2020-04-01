using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project1.WebUI.Models;

namespace Project1.WebUI.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "Customer ID:")]
        public int CstmId { get; set; }

        [Display(Name = "First Name:")]
        public string CstmFirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string CstmLastName { get; set; }

        [Display(Name = "Email:")]
        public string CstmEmail { get; set; }

        [Display(Name = "Default Store:")]
        public int? CstmDefaultLocation { get; set; }
    }
}
