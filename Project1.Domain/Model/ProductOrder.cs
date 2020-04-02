using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class ProductOrder
    {
        private int _orderCstmId;
        private int? _orderStrId;

        public int OrderId { get; set; }

        public int OrderCstmId
        {
            get => _orderCstmId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _orderCstmId = value;
            }
        }

        public int? OrderStrId
        {
            get => _orderStrId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _orderStrId = value;
            }
        }

        public DateTime? OrderOrdDate { get; set; }

        public List<OrderList> OrderList { get; set; } = new List<OrderList>();
    }
}
