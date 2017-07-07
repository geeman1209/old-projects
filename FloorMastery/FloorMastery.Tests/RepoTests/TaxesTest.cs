using FloorMastery.BLL;
using FloorMastery.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Tests.RepoTests
{
    [TestFixture]
    public class TaxesTest
    {
        [Test]
        public void CanLoadTaxes()
        {
            OrderManager manager = OrderManagerFactory.Create();
            TaxesResponse response = manager.FindTaxes();

            Assert.AreEqual(response.taxes.Count, 4);
            Assert.AreEqual(response.taxes[0].StateName, "Ohio");
            Assert.AreEqual(response.taxes[0].StateAbbreviation, "OH");
            Assert.AreEqual(response.taxes[1].TaxRate, 6.75M);
            Assert.AreEqual(response.taxes[2].StateName, "Michigan");
            Assert.AreEqual(response.taxes[3].TaxRate, 6.00M);
        }
    }
}
