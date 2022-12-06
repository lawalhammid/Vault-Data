using System;
using VaultData.DeveloperTest.Services;
using VaultData.DeveloperTest.Types;

namespace VaultData.DeveloperTest.Data
{
    public class BackupAccountDataStore: IAccountDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access backup data base to retrieve account, code removed for brevity 
            return new Account
            {
                AccountNumber = "0123456789",
                AccountType = AccountType.Premium,
                Status = AccountStatus.Live,
                IsReadOnly = false,
                FirstName = "Opeyemi",
                LastName = "Lawal",
                LastUpdated = DateTime.Now.AddDays(-1),
            }; ;
        }
            
        public bool UpdateAccount(Account account)
        {
            // Update account in backup database, code removed for brevity
            return true;
        }
    }
}