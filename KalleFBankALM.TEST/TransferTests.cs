using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KalleFBankALM.TEST
{
    public class TransferTests
    {
        private string _fromAccountNumber = "54321";
        private string _toAcccountNumber = "345123";
        private decimal _transferAmount = 50m;
        private BankRepository _bankRepo = new BankRepository();

        [Fact]
        public void TransferWithCorrectAccountNumbersAndAmount()
        {
            var fAccountBalance = _bankRepo.GetAccountById(_fromAccountNumber).Balance;
            var tAccountBalance = _bankRepo.GetAccountById(_toAcccountNumber).Balance;
            
            var model = new ViewModels.TransferViewModel
            {
                FromAccountNumber = _fromAccountNumber,
                ToAccountNumber = _toAcccountNumber,
                TransferAmount = _transferAmount
            };

            model = _bankRepo.Transfer(model);
            
            Assert.Equal((model.FromAccount.Balance + _transferAmount), fAccountBalance);
            Assert.Equal((model.ToAccount.Balance - _transferAmount), tAccountBalance);
        }

        [Fact]
        public void TransferWithUnvalidAmount()
        {
            var model = new ViewModels.TransferViewModel
            {
                FromAccountNumber = _fromAccountNumber,
                ToAccountNumber = _toAcccountNumber,
                TransferAmount = 1000m
            };

            model = _bankRepo.Transfer(model);

            Assert.True(model.FromAccount == null);
            Assert.True(model.ToAccount == null);
        }

        [Fact]
        public void TransferWithUnvalidAccountNumber()
        {
            var model = new ViewModels.TransferViewModel
            {
                FromAccountNumber = _fromAccountNumber,
                ToAccountNumber = "112233",
                TransferAmount = _transferAmount
            };

            model = _bankRepo.Transfer(model);

            Assert.True(model.FromAccount == null);
            Assert.True(model.ToAccount == null);
        }
    }
}
