using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class Product
    {
        private string _prodName;
        private string _prodDescription;
        private decimal _prodPrice;

        public int ProdId { get; set; }

        public string ProdName
        {
            get => _prodName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _prodName = value;
            }
        }

        public string ProdDescription { get; set; }

        public decimal ProdPrice
        {
            get => _prodPrice;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
            }
        }

        public List<OrderList> OrderList { get; set; } = new List<OrderList>();

        public List<StoreInventory> StoreInventory { get; set; } = new List<StoreInventory>();
    }
}
