using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project1.Domain.Model;
using Project1.WebUI.Models;

namespace Project1.WebUI.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "Customer ID")]
        public int CstmId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="*First Name is Required")]
        public string CstmFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "*Last Name is Required")]
        public string CstmLastName { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid format")]
        public string CstmEmail { get; set; }

        [Display(Name = "Default Store")]
        public int? CstmDefaultLocation { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
    }
}
