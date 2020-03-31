using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.WebUI.Models;

namespace Project1.WebUI.Models
{
    public class CustomerViewModel
    {
        public int CstmId { get; set; }
        public string CstmFirstName { get; set; }
        public string CstmLastName { get; set; }
        public string CstmEmail { get; set; }
        public int? CstmDefaultLocation { get; set; }
    }
}
