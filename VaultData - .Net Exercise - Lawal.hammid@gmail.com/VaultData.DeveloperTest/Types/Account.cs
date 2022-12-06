using System;

namespace VaultData.DeveloperTest.Types
{
    public class Account
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
