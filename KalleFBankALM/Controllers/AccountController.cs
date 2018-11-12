using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace KalleFBankALM.Controllers
{
    public class AccountController : Controller
    {
        private IBankRepository _bankRepository;

        public AccountController(IBankRepository bankRepo)
        {
            _bankRepository = bankRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(string account, decimal amount)
        {
            var selectedAccount = _bankRepository.Customers
                .FirstOrDefault(a => a.CustomerAccounts.Exists(b => b.AccountNumber == account))
                ?.CustomerAccounts.First(c => c.AccountNumber == account);

            if (amount <= 0)
            {
                return new JsonResult("Amount cant be negative or zero!");
            }

            if (selectedAccount != null)
            {
                var initialBalance = selectedAccount.Balance;
                selectedAccount.Withdraw(amount);
                if (initialBalance > selectedAccount.Balance)
                {
                    return new JsonResult($"New balance is: {selectedAccount.Balance}");
                }
                return new JsonResult("Amount greater than balance!");
            }   

            return new JsonResult("Account was not found!");
        }

        [HttpPost]
        public IActionResult Deposit(string account, decimal amount)
        {
            var selectedAccount = _bankRepository.Customers
                .FirstOrDefault(a => a.CustomerAccounts.Exists(b => b.AccountNumber == account))
                ?.CustomerAccounts.First(c => c.AccountNumber == account);

            if (amount <= 0)
            {
                return new JsonResult("Amount cant be negative or zero!");
            }

            if (selectedAccount != null)
            {
                var initialBalance = selectedAccount.Balance;
                selectedAccount.Deposit(amount);
                if (initialBalance < selectedAccount.Balance)
                {
                    return new JsonResult($"New balance is: {selectedAccount.Balance}");
                }
                return new JsonResult("Invalid amount!");
            }

            return new JsonResult("Account was not found!");
        }

    }
}