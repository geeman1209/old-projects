using NUnit.Framework;
using SGBank.BLL.Deposit_Rules;
using SGBank.BLL.Withdraw_Rules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("23456", "Premium Account", 500, AccountType.Free, 250, false)]
        [TestCase("23456", "Premium Account", 500, AccountType.Premium, -100, false)]
        [TestCase("23456", "Premium Account", 500, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
       
        [TestCase("23456", "Premium Account", 500, AccountType.Free, -100, 500, false)]
        [TestCase("23456", "Premium Account", 500, AccountType.Premium, 100, 500, false)]
        [TestCase("23456", "Premium Account", 550, AccountType.Premium, -50, 500, true)]
        [TestCase("23456", "Premium Account", 500, AccountType.Premium, -1050, -560, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

            if (response.Success == true)
            {
                Assert.AreEqual(newBalance, account.Balance);
            }

        }
    }
}
