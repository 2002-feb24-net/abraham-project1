using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class StoreLocation
    {
        private string _locStreet;
        private string _locCity;
        private string _locCountry;

        public int LocId { get; set; }

        public string LocStreet
        {
            get => _locStreet;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _locStreet = value;
            }
        }

        public string LocCity
        {
            get => _locCity;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _locCity = value;
            }
        }

        public string LocCountry
        {
            get => _locCountry;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _locCountry = value;
            }
        }

        public List<ProductOrder> ProductOrder { get; set; } = new List<ProductOrder>();

        public List<StoreInventory> StoreInventory { get; set; } = new List<StoreInventory>();
    }
}
