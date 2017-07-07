using FloorMastery.BLL;
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
    public class ProductTest
    {
        [Test]
        public void CanLoadProducts()
        {
            OrderManager manager = OrderManagerFactory.Create();
            ProductResponse productList = manager.FindProducts();

            Assert.AreEqual(productList.products.Count, 4);
            Assert.AreEqual(productList.products[0].ProductType, "Carpet");
            Assert.AreEqual(productList.products[1].LaborCostPerSquareFoot, 2.10M);
            Assert.AreEqual(productList.products[2].CostPerSquareFoot, 3.50M);
            
        }
    }
}
