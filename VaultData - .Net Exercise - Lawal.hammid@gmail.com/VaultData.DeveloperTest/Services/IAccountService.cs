using VaultData.DeveloperTest.Data;
using VaultData.DeveloperTest.Types;

namespace VaultData.DeveloperTest.Services
{
    public interface IAccountService
    {
        UpdateAccountResult UpdateAccount(UpdateAccountRequest request);
        Account GetAccountByAccountNo(string AccountNumber);
        UpdateAccountResult CanAccountBeUpdated(Account account, UpdateAccountRequest request);
        IAccountDataStore ReturnDataStoreByType(string dataStoreType);
    }
}