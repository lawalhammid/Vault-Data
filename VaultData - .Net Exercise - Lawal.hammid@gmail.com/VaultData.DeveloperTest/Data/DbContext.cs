using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VaultData.DeveloperTest.Data
{
    public class DbContext : IDbContext
    {
        public IAccountDataStore GetDataStoreByConnectionString(string dataStoreType)
        {
            switch (dataStoreType)
            {
                case "BackUp":
                    return new  BackupAccountDataStore() ;
                default:
                    return new AccountDataStore();
            }
        }
    }
}