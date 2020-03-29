using Project1.Domain.Interface;
using Project1.Domain.Model;
using Project1.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.DataAccess.Repositories
{
    public class Project1Repository : IProject1Repository
    {
        private readonly Project0DbContext _dbContext;

        public void AddCustomer(Domain.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Domain.Model.ProductOrder productOrder, Domain.Model.OrderList orderList)
        {
            throw new NotImplementedException();
        }

        public Domain.Model.Customer GetCustomerByName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Domain.Model.ProductOrder GetOrderByLocation(string locCity)
        {
            throw new NotImplementedException();
        }

        public Domain.Model.ProductOrder GetOrderByName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
