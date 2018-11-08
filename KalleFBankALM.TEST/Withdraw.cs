using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KalleFBankALM.TEST
{
    public class Withdraw
    {
        private decimal _testAmountCorrect = 40m;
        private decimal _testAmountTooGreat = 100m;
        private decimal _testBalance = 80m;

        private decimal _testAmountNegative = -10m;

        [Fact]
        public void WithdrawsFromBalanceWhenAmountIsCorrect()
        {
            var account = new Account("1", _testBalance);

            account.Withdraw(_testAmountCorrect);

            Assert.True(_testBalance > account.Balance);
        }

        [Fact]
        public void DontWithdrawIfAmountIsNegative()
        {
            var account = new Account("1", _testBalance);
            account.Withdraw(_testAmountNegative);

            Assert.Equal(_testBalance,account.Balance);
        }
        [Fact]
        public void DontWithdrawIfAmountIsGreaterThanBalance()
        {
            var account = new Account("1", _testBalance);
            account.Withdraw(_testAmountTooGreat);

            Assert.Equal(_testBalance, account.Balance);
        }


    }
}
