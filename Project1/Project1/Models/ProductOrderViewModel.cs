using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebUI.Models
{
    public class ProductOrderViewModel
    {
        public int OrderId { get; set; }

        public int OrderCstmId { get; set; }

        public int? OrderStrId { get; set; }

        public DateTime? OrderOrdDate { get; set; }

    }
}
