using Moq;
using NUnit.Framework;
using System;
using VaultData.DeveloperTest.Data;
using VaultData.DeveloperTest.Services;
using VaultData.DeveloperTest.Types;

namespace VaultData.DeveloperTest.Tests.UnitTesting
{
    public class AccountUnitTest
    {
        private Mock<DbContext> _dbContext;
        private AccountService _accountService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<DbContext>();
            _accountService = new AccountService(_dbContext.Object);
        }

        [Test]
        public void UpdateAccountTest()
        {
            UpdateAccountRequest _updateAccountRequest = new UpdateAccountRequest();
            _updateAccountRequest.AccountNumber  = "0123456789";
            _updateAccountRequest.LastName = "LawalNew";

            var testResult = _accountService.UpdateAccount(_updateAccountRequest);

            Assert.IsNotNull(testResult);
            Assert.IsTrue(testResult.Success);
        }

        [Test]
        public void GetAccountByAccountNoTest()
        {
            string AccountNumber = "0123456789";

            var testResult = _accountService.GetAccountByAccountNo(AccountNumber);

            Assert.IsNotNull(testResult);
            Assert.IsTrue(testResult.AccountNumber == AccountNumber);
        }

        [Test]
        public void CanAccountBeUpdatedTest()
        {
            var account = new Account
            {
                AccountNumber = "",
                AccountType = AccountType.Premium,
                Status = AccountStatus.Live,
                IsReadOnly = false,
                FirstName = "Opeyemi",
                LastName = "Lawal",
                LastUpdated = DateTime.Now.AddDays(-1),
            };

            var updateAccountRequest = new UpdateAccountRequest
            {
                 AccountNumber = "0123456789",
                 LastName = "LawalNew"
            };

            account.AccountNumber = "0123456789";
            account.LastName = "Lawal Opeyemi";

            var testResult = _accountService.CanAccountBeUpdated(account, updateAccountRequest);

            Assert.IsNotNull(testResult);
            Assert.IsTrue(testResult.Success);
        }
    }
}