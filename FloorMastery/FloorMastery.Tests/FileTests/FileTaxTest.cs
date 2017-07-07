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
    public class FileTaxTest
    {
        [Test]
        public void LoadTaxFile()
        {
            string _path2file = @"C:\Data\Taxes.txt";

            FileTaxesRepository data = new FileTaxesRepository(_path2file);

            List<Taxes> taxes = data.LoadTax();

            Assert.AreEqual("IN", taxes[3].StateAbbreviation);
            Assert.AreEqual("Ohio", taxes[0].StateName);
            Assert.AreEqual(4, taxes.Count);
        }
    }
}
