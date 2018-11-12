using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalleFBankALM
{
    public class Account
    {
        private decimal _balance;
        private string _accountNumber;

        public string AccountNumber
        {
            get => _accountNumber;
        }
        public decimal Balance { get => _balance;}

        public Account(string accNum, decimal balance)
        {
            _accountNumber = accNum;
            _balance = balance;
        }

        public void Withdraw(decimal amount)
        {
            if (HasCovarage(amount))
            {
                _balance -= amount;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }

        private bool HasCovarage(decimal amount)
        {
            return _balance >= amount && amount > 0;
        }

    }
}
