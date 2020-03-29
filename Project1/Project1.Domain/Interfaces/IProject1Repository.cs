using System;
using System.Collections.Generic;
using System.Text;
using Project1.Domain.Model;

namespace Project1.Domain.Interface
{
    public interface IProject1Repository
    {
        Customer GetCustomerByName(string firstName, string lastName);

        ProductOrder GetOrderByName(string firstName, string lastName);

        ProductOrder GetOrderByLocation(string locCity);

        void AddCustomer(Customer customer);

        void AddOrder(ProductOrder productOrder, OrderList orderList);

        void Save();
    }
}
