using VaultData.DeveloperTest.Data;
using VaultData.DeveloperTest.Types;
using System.Configuration;
using System;

namespace VaultData.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IDbContext _dbContext;
        public AccountService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UpdateAccountResult UpdateAccount(UpdateAccountRequest request)
        {
            var result = new UpdateAccountResult();

            var account = GetAccountByAccountNo(request.AccountNumber);

            if (account != null)
            {
                var canAccountBeUpdatedResult = CanAccountBeUpdated(account, request);

                if (canAccountBeUpdatedResult.Success)
                {
                    account.LastName = request.LastName;
                    account.LastUpdated = DateTime.Now;

                    var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
                    var BackupDataOrLiveData = ReturnDataStoreByType(dataStoreType);

                    var updateResult = BackupDataOrLiveData.UpdateAccount(account);
                    result.Success = updateResult;
                    return result;
                }
            }
            
            return result;
        }

        public Account GetAccountByAccountNo(string AccountNumber)
        {
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
            var BackupDataOrLiveData = ReturnDataStoreByType(dataStoreType);
            return BackupDataOrLiveData.GetAccount(AccountNumber);
        }
        public UpdateAccountResult CanAccountBeUpdated(Account account, UpdateAccountRequest request)
        {
            var result = new UpdateAccountResult();
            result.Success = true;
            switch (account.AccountType)
            {
                case AccountType.Free:
                    result.Success = false;
                    break;

                case AccountType.Standard:
                    if (account.Status != AccountStatus.Live)
                    {
                         result.Success = false;
                        break;
                    }
                    if (account.IsReadOnly)
                    {
                        result.Success = false;
                        break;
                    }
                    if ((DateTime.Now - account.LastUpdated).TotalDays > 30)
                    {
                        result.Success = false;
                        break;
                    }
                    if (account.LastName == request.LastName)
                    {
                        result.Success = false;
                        break;
                    }
                    break;
                case AccountType.Premium:
                    if (account.Status != AccountStatus.Live)
                    {
                        result.Success = false;
                        break;
                    }
                    if ((DateTime.Now - account.LastUpdated).TotalDays > 90)
                    {
                        result.Success = false;
                        break;
                    }
                    if (account.LastName == request.LastName)
                    {
                        result.Success = false;
                        break;
                    }
                    break;
            }
            return result;
        }

        public IAccountDataStore ReturnDataStoreByType(string dataStoreType)
        {
           return _dbContext.GetDataStoreByConnectionString(dataStoreType);
        }
    }
}