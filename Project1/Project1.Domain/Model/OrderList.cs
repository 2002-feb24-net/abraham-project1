using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class OrderList
    {
        private int? _lstOrderId;
        private int? _lstProdId;

        public int LstId { get; set; }

        public int? LstOrderId
        {
            get => _lstOrderId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _lstOrderId = value;
            }
        }

        public int? LstProdId
        {
            get => _lstProdId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _lstProdId = value;
            }
        }
    }
}
