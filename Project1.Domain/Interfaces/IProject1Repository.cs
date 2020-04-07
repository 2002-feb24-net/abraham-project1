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

        void UpdateCustomer(Customer customer);

        void AddProductOrder(ProductOrder productOrder);

        void AddOrderList(OrderList orderList);

        int GetMaxProductOrderID();

        int GetMaxOrderListID();

        ProductOrder GetProductOrder(int id);

        StoreLocation GetStoreProductOrder(int? id);

        IEnumerable<OrderList> GetOrderList(int id);

        IEnumerable<Product> GetProduct(int? id);

        IEnumerable<Product> GetAllProducts();

        IEnumerable<StoreLocation> GetStoreLocations();

        void Save();
    }
}
