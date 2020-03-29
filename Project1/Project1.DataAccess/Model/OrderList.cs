using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Model
{
    public partial class OrderList
    {
        public int LstId { get; set; }
        public int? LstOrderId { get; set; }
        public int? LstProdId { get; set; }

        public virtual ProductOrder LstOrder { get; set; }
        public virtual Product LstProd { get; set; }
    }
}
