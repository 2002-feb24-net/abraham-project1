using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class Customer
    {
        private string  _cstmFirstName;
        private string _cstmLastName;
        private string _cstmEmail;
        private int? _cstmDefaultStoreLocation;

        public int CstmId { get; set; }

        public string CstmFirstName
        {
            get => _cstmFirstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _cstmFirstName = value;
            }
        }

        public string CstmLasttName
        {
            get => _cstmLastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _cstmLastName = value;
            }
        }

        public string CstmEmail
        {
            get => _cstmEmail;
            set
            {
                var addr = new System.Net.Mail.MailAddress(value);
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                if(addr.Address != value)
                {
                    throw new FormatException("Invalid email format. Must contain '@' and .net, .edu, .com etc.");
                }
                _cstmEmail = value;
            }
        }

        public int? CstmDefaultStoreLocation
        {
            get => _cstmDefaultStoreLocation;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
            }
        }

        public List<ProductOrder> ProductOrder { get; set; } = new List<ProductOrder>();
    }
}
