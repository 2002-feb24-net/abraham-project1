using System;
using System.Collections.Generic;
using System.Text;
using Project1.Domain.Model;

namespace Project1.Domain.Interface
{
    public interface IProject1Repository
    {
        Customer GetCustomerByFullName(string fullName);

        void AddCustomer(Customer customer);

        ProductOrder GetProductOrder(int id);

        IEnumerable<OrderList> GetOrderList(int id);

        IEnumerable<Product> GetProduct(int? id);

        void Save();
    }
}
