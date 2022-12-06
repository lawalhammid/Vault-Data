using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultData.DeveloperTest.Types;

namespace VaultData.DeveloperTest.Tests.Types
{
    internal sealed class Account
    {
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus Status { get; set; }
        public bool IsReadOnly { get; set; }
        public DateTime LastUpdated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}