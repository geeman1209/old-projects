using FloorMastery.Data;
using FloorMastery.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Tests.FileTests
{
    [TestFixture]
    public class FileProductTest
    {
        [Test]
        public void LoadProducts()
        {
            string _path2file = @"C:\Data\Products.txt";

            FileProductRepository data = new FileProductRepository(_path2file);

            List<Products> products = data.ListProducts();

            Assert.AreEqual("Wood", products[3].ProductType);
            Assert.AreEqual(5.15, products[3].CostPerSquareFoot);
            Assert.AreEqual(4.75, products[3].LaborCostPerSquareFoot);
            Assert.AreEqual(4, products.Count());
        }
    }
}
