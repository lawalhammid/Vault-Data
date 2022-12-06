1. DbContext is use to return the object(AccountDataStore or BackupAccountDataStore) to call base on datastore so that in 
   AccountService I would call DbContext and pass the datastore type to return the appropriate datastore class
2. IAccountDataStore interface is used to abstract the functionalities AccountDataStore or BackupAccountDataStore have
3. Implemented unit testing using NUint, Moq in VaultData.DeveloperTest.Tests project

 I used Strategy design and Circular dependency to solve the issue of which datastore to return based on the datastore type passed