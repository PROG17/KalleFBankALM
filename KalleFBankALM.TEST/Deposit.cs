using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KalleFBankALM.TEST
{
    public class Deposit
    {
        private decimal _testAmountCorrect = 40m;
        private decimal _testBalance = 80m;

        [Fact]
        public void DepositsWhenAmountIsCorrect()
        {
            var account = new Account("1", _testBalance);

            account.Deposit(_testAmountCorrect);

            Assert.True(_testBalance < account.Balance);
        }
    }
}
