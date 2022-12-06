using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultData.DeveloperTest.Data
{
    public interface IDbContext
    {
        IAccountDataStore GetDataStoreByConnectionString(string dataStoreType);
    }
}