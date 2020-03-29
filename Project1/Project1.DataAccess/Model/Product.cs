using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Model
{
    public partial class Product
    {
        public Product()
        {
            OrderList = new HashSet<OrderList>();
            StoreInventory = new HashSet<StoreInventory>();
        }

        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public decimal ProdPrice { get; set; }

        public virtual ICollection<OrderList> OrderList { get; set; }
        public virtual ICollection<StoreInventory> StoreInventory { get; set; }
    }
}
