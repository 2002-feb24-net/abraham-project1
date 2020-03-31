using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.DataAccess
{
    public static class Mapper
    {
        public static Domain.Model.Customer MapCustomerWithOrders(Model.Customer customer)
        {
            return new Domain.Model.Customer
            {
                CstmId = customer.CstmId,
                CstmFirstName = customer.CstmFirstName,
                CstmLastName = customer.CstmLastName,
                CstmEmail = customer.CstmEmail,
                CstmDefaultStoreLocation = customer.CstmDefaultStoreLoc,
                ProductOrder = customer.ProductOrder.Select(MapProductOrder).ToList()
            };     
        }

        public static Model.Customer MapCustomerWithOrders(Domain.Model.Customer customer)
        {
            return new Model.Customer
            {
                CstmId = customer.CstmId,
                CstmFirstName = customer.CstmFirstName,
                CstmLastName = customer.CstmLastName,
                CstmEmail = customer.CstmEmail,
                CstmDefaultStoreLoc = customer.CstmDefaultStoreLocation,
                ProductOrder = customer.ProductOrder.Select(MapProductOrder).ToList()
            };
        }

        public static Domain.Model.ProductOrder MapProductOrder(Model.ProductOrder productOrder)
        {
            return new Domain.Model.ProductOrder
            {
                OrderId = productOrder.OrderId,
                OrderCstmId = productOrder.OrderCstmId,
                OrderStrId = productOrder.OrderStrId,
                OrderOrdDate = productOrder.OrderOrdDate,
                OrderList = productOrder.OrderList.Select(MapOrderLists).ToList()

            };
        }

        public static Model.ProductOrder MapProductOrder(Domain.Model.ProductOrder productOrder)
        {
            return new Model.ProductOrder
            {
                OrderId = productOrder.OrderId,
                OrderCstmId = productOrder.OrderCstmId,
                OrderStrId = productOrder.OrderStrId,
                OrderOrdDate = productOrder.OrderOrdDate,
                OrderList = productOrder.OrderList.Select(MapOrderLists).ToList()

            };
        }

        public static Domain.Model.OrderList MapOrderLists(Model.OrderList orderList)
        {
            return new Domain.Model.OrderList
            {
                LstId = orderList.LstId,
                LstOrderId = orderList.LstOrderId,
                LstProdId = orderList.LstProdId
            };
        }

        public static Model.OrderList MapOrderLists(Domain.Model.OrderList orderList)
        {
            return new Model.OrderList
            {
                LstId = orderList.LstId,
                LstOrderId = orderList.LstOrderId,
                LstProdId = orderList.LstProdId
            };
        }

        public static Domain.Model.StoreInventory MapStoreInventory(Model.StoreInventory storeInventory)
        {
            return new Domain.Model.StoreInventory
            {
                InvId = storeInventory.InvId,
                InvProdId = storeInventory.InvProdId,
                InvStoreLoc = storeInventory.InvStoreLoc,
                InvProdInventory = storeInventory.InvProdInventory
            };
        }

        public static Model.StoreInventory MapStoreInventory(Domain.Model.StoreInventory storeInventory)
        {
            return new Model.StoreInventory
            {
                InvId = storeInventory.InvId,
                InvProdId = storeInventory.InvProdId,
                InvStoreLoc = storeInventory.InvStoreLoc,
                InvProdInventory = storeInventory.InvProdInventory
            };
        }

        public static Domain.Model.StoreLocation MapStoreLocation(Model.StoreLocation storeLocation)
        {
            return new Domain.Model.StoreLocation
            {
                LocId = storeLocation.LocId,
                LocStreet = storeLocation.LocStreet,
                LocCity = storeLocation.LocCity,
                LocCountry = storeLocation.LocCountry,
                ProductOrder = storeLocation.ProductOrder.Select(MapProductOrder).ToList(),
                StoreInventory = storeLocation.StoreInventory.Select(MapStoreInventory).ToList()
            };
        }

        public static Model.StoreLocation MapStoreLocation(Domain.Model.StoreLocation storeLocation)
        {
            return new Model.StoreLocation
            {
                LocId = storeLocation.LocId,
                LocStreet = storeLocation.LocStreet,
                LocCity = storeLocation.LocCity,
                LocCountry = storeLocation.LocCountry,
                ProductOrder = storeLocation.ProductOrder.Select(MapProductOrder).ToList(),
                StoreInventory = storeLocation.StoreInventory.Select(MapStoreInventory).ToList()
            };
        }

        public static Domain.Model.Product MapPrduct(Model.Product product)
        {
            return new Domain.Model.Product
            {
                ProdId = product.ProdId,
                ProdName = product.ProdName,
                ProdDescription = product.ProdDescription,
                ProdPrice = product.ProdPrice,
                OrderList = product.OrderList.Select(MapOrderLists).ToList(),
                StoreInventory = product.StoreInventory.Select(MapStoreInventory).ToList()
            };
        }

        public static Model.Product MapPrduct(Domain.Model.Product product)
        {
            return new Model.Product
            {
                ProdId = product.ProdId,
                ProdName = product.ProdName,
                ProdDescription = product.ProdDescription,
                ProdPrice = product.ProdPrice,
                OrderList = product.OrderList.Select(MapOrderLists).ToList(),
                StoreInventory = product.StoreInventory.Select(MapStoreInventory).ToList()
            };
        }
    }
}
