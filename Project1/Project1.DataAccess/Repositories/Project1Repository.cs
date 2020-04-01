using Project1.Domain.Interface;
using Project1.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project1.DataAccess.Repositories
{
    public class Project1Repository : IProject1Repository
    {
        private readonly Project0DbContext _dbContext;

        public Project1Repository(Project0DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
        }

        public void AddCustomer(Domain.Model.Customer customer)
        {
            Customer entity = Mapper.MapCustomerWithOrders(customer);
            _dbContext.Add(entity);
        }

        public void AddOrder(Domain.Model.ProductOrder productOrder, Domain.Model.OrderList orderList)
        {
            ProductOrder entity = Mapper.MapProductOrder(productOrder);
            OrderList entity2 = Mapper.MapOrderLists(orderList);
            _dbContext.Add(entity);
            _dbContext.Add(entity2);
        }

        public Domain.Model.Customer GetCustomerById(string fullName)
        {
            var customer = _dbContext.Customer.Include(p => p.ProductOrder)
                .FirstOrDefault(x => x.CstmFirstName + " " + x.CstmLastName == fullName);

            if (customer != null)
            {
                return Mapper.MapCustomerWithOrders(customer);
            }
            return null;

        }

        public Domain.Model.ProductOrder GetOrderById(int id) =>
            Mapper.MapProductOrder(_dbContext.ProductOrder.Find(id));
        public IEnumerable<Domain.Model.ProductOrder> GetStoreHistory(int id)
        {
            IQueryable<ProductOrder> items = _dbContext.ProductOrder
                .Include(r => r.OrderList).AsNoTracking();

            items = items.Where(r => r.OrderStrId == id);

            return items.Select(Mapper.MapProductOrder);
        }

        public IEnumerable<Domain.Model.ProductOrder> GetCustomerHistory(int id)
        {
            IQueryable<ProductOrder> items = _dbContext.ProductOrder
                .Include(r => r.OrderList).AsNoTracking();

            items = items.Where(r => r.OrderCstmId == id);

            return items.Select(Mapper.MapProductOrder);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
