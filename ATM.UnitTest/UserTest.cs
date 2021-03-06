﻿
using System;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM.Business;
using ATM.Business.Exceptions;

namespace ATM.UnitTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_Should_Be_Able_To_Login_Using_The_Account_Number_And_Password()
        {

            var db = new Database{Test = true};

            var checkingAccount = new CheckingAccount("123456789");
            var savingsAccount = new SavingsAccount("987654321");

            var user = new User(checkingAccount, savingsAccount)
            {
                Name = "Joe Doe",
                Password = "secret"
            };
            db.Users.Add(user);
            db.Save();



            var accountNumber = "123456789";
            var password = "secret";

            var loggedUser = Authentication.Login(accountNumber, password);
            Assert.AreEqual(loggedUser.CheckingAccount.Number, accountNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticationException))]
        public void User_Should_Throw_An_Exception_When_The_Account_Number_Or_Password_Is_Wrogn()
        {
            var accountNumber = "45845225";
            var password = "secret22222";

            var user = Authentication.Login(accountNumber, password);
        }

        [TestMethod]
        public void User_Should_See_The_Balance_Of_SavingsAccount()
        {
            var user = new User();
            user.SavingsAccount.Deposit(500.0);
            Assert.AreEqual(user.SavingsAccount.Balance, 500.0);
        }

        [TestMethod]
        public void User_Should_See_The_Balance_Of_CheckingAccount()
        {
            var user = new User();
            user.CheckingAccount.Deposit(500.0);
            Assert.AreEqual(user.CheckingAccount.Balance, 500.0);
        }

        [TestMethod]
        public void User_Should_Be_Able_To_Transfer_From_Savings_To_Checking()
        {
            var user = new User();
            user.SavingsAccount.Deposit(100.0);
            user.CheckingAccount.Deposit(500.0);

            user.SavingsAccount.TransferTo(user.CheckingAccount, 50.0);

            Assert.AreEqual(user.CheckingAccount.Balance, 550.0);
            Assert.AreEqual(user.SavingsAccount.Balance, 50.0);
        }

        [TestMethod]
        public void User_Needs_To_Be_Warned_If_Their_Savings_Account_Drops_Bellow_500()
        {
            var user = new User();
            user.SavingsAccount.Deposit(600.0);

            Assert.IsFalse(user.SavingsAccount.BalanceWarning);

            user.SavingsAccount.Withdraw(300.0);

            Assert.IsTrue(user.SavingsAccount.BalanceWarning);
        }

        [TestMethod]
        [ExpectedException(typeof(WithdrawUpTo500Exception))]
        public void User_Needs_To_Be_Able_To_Withdraw_Up_To_500_From_Checking_Account()
        {
            var user = new User();
            user.CheckingAccount.Deposit(1000.0);

            user.CheckingAccount.Withdraw(600.0);
        }
    }
}
