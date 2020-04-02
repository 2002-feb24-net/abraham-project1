using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class StoreInventory
    {
        private int? _invProdId;
        private int? _invStoreLoc;
        private int _invProdInventory;

        public int InvId { get; set; }

        public int? InvProdId
        {
            get => _invProdId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _invProdId = value;
            }

        }
        public int? InvStoreLoc
        {
            get => _invStoreLoc;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _invStoreLoc = value;
            }

        }
        public int InvProdInventory
        {
            get => _invProdInventory;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _invProdInventory = value;
            }

        }
    }
}
