using System;
using System.Collections.Generic;
using System.Text;
using Project1.Domain.Model;

namespace Project1.Domain.Interface
{
    public interface IProject1Repository
    {
        Customer GetCustomerById(string fullName);

        ProductOrder GetOrderById(int id);

        IEnumerable<ProductOrder> GetCustomerHistory(int id);

        IEnumerable<ProductOrder> GetStoreHistory(int id);

        void AddCustomer(Customer customer);

        void AddOrder(ProductOrder productOrder, OrderList orderList);

        void Save();
    }
}
