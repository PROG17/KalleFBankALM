using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalleFBankALM
{
    public class BankRepository : IBankRepository
    {
        //public IQueryable<Account> Accounts = new List<Account>
        //{
        //    new Account{}, new Account()
        //}.AsQueryable<Account>();
        public IQueryable<Customer> Customers => new List<Customer> {
            new Customer
            {
                CustomerAccounts = new List<Account>
                {
                    new Account
                    {
                        AccountNumber = "12345",
                        Balance = 100m
                    }
                },
                CustomerId = 1,
                Name = "Jens"
            },
            new Customer
            {
                CustomerAccounts = new List<Account>
                {
                    new Account
                    {
                        AccountNumber = "54321",
                        Balance = 200m
                    }
                },
                CustomerId = 2,
                Name = "Egi"
            },
            new Customer
            {
                CustomerAccounts = new List<Account>
                {
                    new Account
                    {
                        AccountNumber = "345123",
                        Balance = 300m
                    }
                },
                CustomerId = 3,
                Name = "Kalle"
            },

        }.AsQueryable<Customer>();
        
    }
}
