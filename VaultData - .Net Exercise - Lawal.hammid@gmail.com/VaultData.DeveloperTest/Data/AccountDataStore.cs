using System;
using VaultData.DeveloperTest.Types;

namespace VaultData.DeveloperTest.Data
{
    public class AccountDataStore: IAccountDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account
            {
                AccountNumber = "0123456789",
                AccountType = AccountType.Premium,
                Status = AccountStatus.Live,
                IsReadOnly = false,
                FirstName = "Opeyemi",
                LastName = "Lawal",
                LastUpdated = DateTime.Now.AddDays(-1),
            }; 
        }

        public bool UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
            return true;
        }
    }
}