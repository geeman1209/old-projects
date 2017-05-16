using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Tests
{
    [TestFixture]
    public class FileAccountTests
    {
        private const string _filepath = @"C:\Users\gabreu\Documents\BitBucket\gabriel-abreu-individual-work\SGBank\Accounts.txt";

        private const string _oData = @"C:\Users\gabreu\Documents\BitBucket\gabriel-abreu-individual-work\SGBank\AccountsSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filepath))
            {
                File.Delete(_filepath);
            }
            File.Copy(_oData, _filepath);
        }

        [Test]
        public void CanReadData()
        {
            FileAccountRepository repo = new FileAccountRepository(_filepath);

            List<Account> accounts = repo.AccountList();

            Assert.AreEqual(3, accounts.Count());

            Account verify = accounts[0];

            Assert.AreEqual("11111", verify.AccountNumber);
            Assert.AreEqual("Free Customer", verify.Name);
            Assert.AreEqual(100, verify.Balance);
            Assert.AreEqual(AccountType.Free, verify.Type);
        }

        [Test]
        public void CanAddandUpdateAccount()
        {
            FileAccountRepository repo = new FileAccountRepository(_filepath);

            List<Account> accounts = repo.AccountList();

            Account newAccount = new Account();

            newAccount.AccountNumber = "55555";
            newAccount.Name = "Jazzy Jeff";
            newAccount.Balance = 50000;
            newAccount.Type = AccountType.Premium;

            accounts.Add(newAccount);

            Assert.AreEqual(4, accounts.Count());

            Account verify = accounts[3];

            Assert.AreEqual("55555", verify.AccountNumber);
            Assert.AreEqual("Jazzy Jeff", verify.Name);
            Assert.AreEqual(50000, verify.Balance);
            Assert.AreEqual(AccountType.Premium, verify.Type);

        }

    }
}
