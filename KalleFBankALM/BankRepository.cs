using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalleFBankALM
{
    public class BankRepository : IBankRepository
    {
        private IQueryable<Customer> _customers;

        public BankRepository()
        {
            _customers = new List<Customer> {
                new Customer
                {
                    CustomerAccounts = new List<Account>
                    {
                        new Account("12345", 100m)
                    },
                    CustomerId = 1,
                    Name = "Jens"
                },
                new Customer
                {
                    CustomerAccounts = new List<Account>
                    {
                        new Account("54321", 200m)
                    },
                    CustomerId = 2,
                    Name = "Egi"
                },
                new Customer
                {
                    CustomerAccounts = new List<Account>
                    {
                        new Account("345123", 300m)
                    },
                    CustomerId = 3,
                    Name = "Kalle"
                },

            }.AsQueryable<Customer>();
        }

        public IQueryable<Customer> Customers { get => _customers; set => _customers = value; }

        //public IQueryable<Customer> Customers => new List<Customer> {
        //    new Customer
        //    {
        //        CustomerAccounts = new List<Account>
        //        {
        //            new Account("12345", 100m)
        //        },
        //        CustomerId = 1,
        //        Name = "Jens"
        //    },
        //    new Customer
        //    {
        //        CustomerAccounts = new List<Account>
        //        {
        //            new Account("54321", 200m)
        //        },
        //        CustomerId = 2,
        //        Name = "Egi"
        //    },
        //    new Customer
        //    {
        //        CustomerAccounts = new List<Account>
        //        {
        //            new Account("345123", 300m)
        //        },
        //        CustomerId = 3,
        //        Name = "Kalle"
        //    },

        //}.AsQueryable<Customer>();

    }
}
