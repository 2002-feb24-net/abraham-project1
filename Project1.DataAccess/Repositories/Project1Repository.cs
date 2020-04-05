using Microsoft.EntityFrameworkCore;
using Project1.DataAccess.Model;
using Project1.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Model.Customer entity = Mapper.MapCustomerWithOrders(customer);
            _dbContext.Add(entity);
        }

        public Domain.Model.Customer GetCustomerByFullName(string fullName)
        {
            var customer = _dbContext.Customer.Include(p => p.ProductOrder)
                .FirstOrDefault(x => x.CstmFirstName + " " + x.CstmLastName == fullName);

            if (customer != null)
            {
                return Mapper.MapCustomerWithOrders(customer);
            }
            return null;

        }

        public IEnumerable<Domain.Model.OrderList> GetOrderList(int id)
        {
            var orderList = _dbContext.OrderList
                            .Include(p => p.LstProd).AsNoTracking();

            orderList = orderList.Where(o => o.LstOrderId == id);

            return orderList.Select(Mapper.MapOrderLists);
        }

        public IEnumerable<Domain.Model.Product> GetProduct(int? id)
        {
            var product = _dbContext.Product
                            .Include(o => o.OrderList)
                            .AsNoTracking();

            product = product.Where(p => p.ProdId == id);

            return product.Select(Mapper.MapPrduct);
        }

        public Domain.Model.ProductOrder GetProductOrder(int id)
        {
            var orderList = _dbContext.ProductOrder
                            .Include(p => p.OrderList)
                            .FirstOrDefault(o => o.OrderCstmId == id);

            return Mapper.MapProductOrder(orderList);
        }

        public IEnumerable<Domain.Model.StoreLocation> GetStoreLocations()
        {
            var storeLoc = _dbContext.StoreLocation;
            return storeLoc.Select(Mapper.MapStoreLocation);
        }

        public IEnumerable<Domain.Model.Product> GetAllProducts()
        {
            var products = _dbContext.Product;
            return products.Select(Mapper.MapPrduct);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
