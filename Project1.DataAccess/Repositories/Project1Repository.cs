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

        public void UpdateCustomer(Domain.Model.Customer customer)
        {
            var cstm = _dbContext.Customer.FirstOrDefault(x => x.CstmId == customer.CstmId);
            cstm.CstmDefaultStoreLoc = customer.CstmDefaultStoreLocation;
            _dbContext.Update(cstm);
        }

        public void AddProductOrder(Domain.Model.ProductOrder productOrder)
        {
            Model.ProductOrder entity = Mapper.MapProductOrder(productOrder);
            _dbContext.Add(entity);
        }

        public int GetMaxProductOrderID()
        {
            int maxId = 0;
            maxId = _dbContext.ProductOrder.Max(p => p.OrderId);
            return maxId;
        }

        public int GetMaxOrderListID()
        {
            int maxId = 0;
            maxId = _dbContext.OrderList.Max(p => p.LstId);
            int orderListID = maxId + 1;
            return orderListID;
        }
        public void AddOrderList(Domain.Model.OrderList orderList)
        {
            Model.OrderList entity = Mapper.MapOrderLists(orderList);
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
                            .FirstOrDefault(o => o.OrderId == id);

            return Mapper.MapProductOrder(orderList);
        }

        public Domain.Model.StoreLocation GetStoreProductOrder(int? id)
        {
            var orderList = _dbContext.StoreLocation
                            .Include(p => p.ProductOrder)
                            .Include(s => s.StoreInventory)
                            .FirstOrDefault(o => o.LocId == id);

            return Mapper.MapStoreLocation(orderList);
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
