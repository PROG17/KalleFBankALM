using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalleFBankALM.ViewModels;

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

        public TransferViewModel Transfer(TransferViewModel model)
        {
            model.Message = null;
            var accountList = GetListOfAccounts();
            var fromAccount = accountList.FirstOrDefault(a => a.AccountNumber == model.FromAccountNumber);
            var toAccount = accountList.FirstOrDefault(a => a.AccountNumber == model.ToAccountNumber);

            if (model.TransferAmount < 1)
            { 
                model.Message = "Transfer amount must be digits and above 0";
                return model;
            }

            if (fromAccount != null && toAccount != null)
            {
                if (TryToMakeTransfer(fromAccount, toAccount, model.TransferAmount))
                {
                    model.FromAccount = fromAccount;
                    model.ToAccount = toAccount;
                    model.Message = "Transfer completed";
                }
                else
                    model.Message = "Not enough money Sender account";
            }
            else
                model.Message = "Sender or Recieving account number is incorrect";

            return model;
        }

        public Account GetAccountById(string accountNumber)
        {
            return GetListOfAccounts().FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        private bool TryToMakeTransfer(Account fromAccount, Account toAccount, decimal amount)
        {
            if (fromAccount.Balance >= amount)
            {
                fromAccount.Withdraw(amount);
                toAccount.Deposit(amount);
                return true;
            }
            else
                return false;
        }

        private List<Account>GetListOfAccounts()
        {
            var list = new List<Account>();
            foreach(var cust in _customers)
            {
                list.AddRange(cust.CustomerAccounts);
            }
            return list;
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
