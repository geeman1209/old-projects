using FloorMastery.BLL;
using FloorMastery.Data;
using FloorMastery.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Tests.FileTests
{
    [TestFixture]
   public class FileOrderTest
    {
        private string _path2test = @"C:\Data\Orders_06012013_Test.txt";
        private string _path2file = @"C:\Data\Orders_06012013.txt";
        private string _path = @"C:\Data\";

        [SetUp]
        public void DeleteTestData()
        {
            if (File.Exists(_path2test))
            {
                File.Delete(_path2test);
            }

            File.Copy(_path2file, _path2test);
        }

        [Test]
        public void LoadOrders()
        {
            DateTime orderDate = DateTime.Parse("06/01/2013");
            FileOrderRepository data = new FileOrderRepository(@"C:\Data\");

            List<Order> orders = data.ShowOrders(orderDate);

            Assert.AreEqual("Wise", orders[0].CustomerName);
            Assert.AreEqual(1, orders[0].OrderNumber);
            Assert.AreEqual(6.25, orders[0].TaxRate);
        }

        [Test]
        public void LoadIndivOrder()
        {
            DateTime orderDate = DateTime.Parse("06/01/2013");
            int orderNumber = 1;
            FileOrderRepository data = new FileOrderRepository(_path);

            Order order = data.FindIndivOrder(orderNumber, orderDate);

            Assert.AreEqual("Wise", order.CustomerName);
            Assert.AreEqual("Wood", order.ProductType);
        }

        [Test]
        public void FileAdd()
        {
            CalculateTotals calculator = new CalculateTotals();
            DateTime orderDate = DateTime.Parse("06/01/2013");
            FileOrderRepository data = new FileOrderRepository(_path);

            Order testOrder = new Order()
            {
                OrderDate = new DateTime(2013, 06, 01),
                CustomerName = "Scrooge McDuck",
                State = "MN",
                TaxRate = 2,
                ProductType = "Tile",
                Area = 500,
                CostPerSquareFoot = 1,
                LaborCostPerSquareFoot = 1
            };

            data.AddOrder(testOrder, orderDate);

            Assert.AreEqual(2, testOrder.OrderNumber);
            Assert.AreEqual(500, calculator.MaterialCost(testOrder));
            Assert.AreEqual(500, calculator.LaborCost(testOrder));
            Assert.AreEqual(20, calculator.Tax(testOrder));
            Assert.AreEqual(1020, calculator.Total(testOrder));
        }
        [Test]
        public void FileEdit()
        {
            DateTime orderDate = DateTime.Parse("06/01/2013");
            int orderNumber = 1;
            FileOrderRepository data = new FileOrderRepository(_path);

            Order order = data.FindIndivOrder(orderNumber, orderDate);

            order.CustomerName = "Beastie Boi";
            order.ProductType = "Tile";
            order.Area = 250M;

            data.EditOrder(orderDate, order);

            Assert.AreEqual("Beastie Boi", order.CustomerName);
            Assert.AreEqual("Tile", order.ProductType);
            Assert.AreEqual(250M, order.Area);

        }

        [Test]
        public void FileDelete()
        {
            DateTime orderDate = DateTime.Parse("06/01/2013");
            int orderNumber = 1;
            FileOrderRepository data = new FileOrderRepository(_path);

            data.DeleteOrder(orderDate, orderNumber);

            List<Order> orders = data.ShowOrders(orderDate);

            Assert.AreEqual(0, orders.Count);
                
        }

          
            

    }
}
