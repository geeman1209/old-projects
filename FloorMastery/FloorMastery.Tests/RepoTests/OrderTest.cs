using FloorMastery.BLL;
using FloorMastery.Data;
using FloorMastery.Models;
using FloorMastery.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Tests
{
    [TestFixture]
   public class OrderTest
    {
        [Test]
        public void CanLoadOrderData()
        {
            OrderManager manager = new OrderManager(new OrderRepository(), new ProductRepository(), new TaxesRepository());
            DateTime date = new DateTime(2017, 03, 03);

            OrderLookupResponse response = manager.LookupOrders(date);

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(2, response.Order.Count);

        }
        [Test]
        public void CanAddOrder()
        {
            CalculateTotals calculator = new CalculateTotals();
            OrderManager manager = new OrderManager(new OrderRepository(), new ProductRepository(), new TaxesRepository());
            Order testOrder = new Order()
            {
                OrderDate = new DateTime(2020, 01, 01),
                CustomerName = "Scrooge McDuck",
                State = "MN",
                TaxRate = 2,
                ProductType = "Tile",
                Area = 500,
                CostPerSquareFoot = 1,
                LaborCostPerSquareFoot = 1
            };

            AddOrderResponse response = manager.addOrder(testOrder, testOrder.OrderDate);

            Assert.AreEqual("Scrooge McDuck", testOrder.CustomerName);
            Assert.AreEqual("MN", testOrder.State);
            Assert.AreEqual("Tile", testOrder.ProductType);
            Assert.AreEqual(500, testOrder.Area);

            //Make sure calculations are made correctly
            Assert.AreEqual(500, calculator.MaterialCost(testOrder));
            Assert.AreEqual(500, calculator.LaborCost(testOrder));
            Assert.AreEqual(20, calculator.Tax(testOrder));
            Assert.AreEqual(1020, calculator.Total(testOrder));
        }

        [Test]
        public void CanEditOrder()
        {
            DateTime orderDate = new DateTime(2017, 03, 03);
            int orderNumber = 1;

            OrderManager manager = new OrderManager(new OrderRepository(), new ProductRepository(), new TaxesRepository());
            OrderLookupResponse response = manager.FindSelectOrder(orderNumber, orderDate);

            Order selectOrder = response.IndivOrder;

            //edit the order
            selectOrder.CustomerName = "Goliath";
            selectOrder.ProductType = "Laminate";

            //load edited order back 
            manager.editOrder(selectOrder, orderDate);

            //Load edited order again
            OrderLookupResponse verify = manager.FindSelectOrder(orderNumber, orderDate);
            Order checker = verify.IndivOrder;

            //check new edited information
            Assert.AreEqual("Goliath", checker.CustomerName);
            Assert.AreEqual("Laminate", checker.ProductType);

            //check unchanged information stayed the same
            Assert.AreEqual("OH", checker.State);
            Assert.AreEqual(100, checker.Area);
        }
    }
}
