﻿using System;
using System.Collections.Generic;
using System.Text;
using ArvidsBowling.Data;
using Xunit;

namespace Tests
{
    public class TransferTests
    {
        [Fact]
        public void CorrectAmountTransferred()
        {
            var repo = BankRepository.Instance();
            var fromAccount = repo.Accounts[0];
            var recievingAccount = repo.Accounts[1];

            decimal transfer = 100;
            var expectedFrom = fromAccount.Balance-transfer;
            var expetedTo = recievingAccount.Balance+transfer;
            repo.Transfer(fromAccount,recievingAccount,100);
            Assert.Equal(expectedFrom, fromAccount.Balance);
            Assert.Equal(expetedTo, recievingAccount.Balance);
        }

        [Fact]
        public void WithdrawInsufficientFunds()
        {
            var repo = BankRepository.Instance();
            var fromAccount = repo.Accounts[0];
            var recievingAccount = repo.Accounts[1];

            decimal withdraw = 10000000;
            decimal expected = fromAccount.Balance;
            Assert.Throws<Exception>(() => repo.Transfer(fromAccount, recievingAccount, withdraw));
            Assert.Equal(expected, fromAccount.Balance);
        }
    }
}
