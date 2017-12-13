using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Data.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Test
{
    [TestClass]
    public class UserTest
    {
        private async Task CreateUser()
        {
            var db = Database.GetInstance();

            var checkingAccount = new CheckingAccount("123456789");
            var savingsAccount = new SavingsAccount("987654321");
            var creditCard = new CreditCard("987654321");

            var user = new User(checkingAccount, savingsAccount, creditCard)
            {
                Name = "Joe Doe",
                Password = "secret"
            };

            db.AddUser(user);

            await db.Save();
        }

        private async Task<User> GetLoggedUser()
        {
            await CreateUser();

            const string accountNumber = "123456789";
            const string password = "secret";
            var user = Authentication.Login(accountNumber, password);
            return user;
        }

        [TestMethod]
        public async Task User_Should_Be_Able_To_Login_Using_The_Account_Number_And_Password()
        {
            var loggedUser = await GetLoggedUser();
            Assert.AreEqual(loggedUser.CheckingAccount.Number, "123456789");
            var db = Database.GetInstance();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticationException))]
        public async Task User_Should_Throw_An_Exception_When_The_Account_Number_Or_Password_Is_Wrong()
        {
            await CreateUser();

            const string accountNumber = "1234567";
            const string password = "secret";
            Authentication.Login(accountNumber, password);

        }

        [TestMethod]
        public async Task User_Should_See_The_Balance_Of_SavingsAccount()
        {
            var user = await GetLoggedUser();
            user.SavingsAccount.Balance = 0;
            user.CheckingAccount.Balance = 0;
            user.SavingsAccount.Deposit(500.0);
            Assert.AreEqual(user.SavingsAccount.Balance, 500.0);
        }

        [TestMethod]
        public async Task User_Should_See_The_Balance_Of_CheckingAccount()
        {
            var user = await GetLoggedUser();
            user.SavingsAccount.Balance = 0;
            user.CheckingAccount.Balance = 0;
            user.CheckingAccount.Deposit(500.0);
            Assert.AreEqual(user.CheckingAccount.Balance, 500.0);
        }

        [TestMethod]
        public async Task User_Should_Be_Able_To_Transfer_From_Savings_To_Checking()
        {
            var user = await GetLoggedUser();
            user.SavingsAccount.Balance = 0;
            user.CheckingAccount.Balance = 0;

            user.SavingsAccount.Deposit(100.0);
            user.CheckingAccount.Deposit(500.0);

            user.SavingsAccount.TransferTo(user.CheckingAccount, 50.0);

            Assert.AreEqual(user.CheckingAccount.Balance, 550.0);
            Assert.AreEqual(user.SavingsAccount.Balance, 50.0);
        }

        [TestMethod]
        public async Task User_Needs_To_Be_Warned_If_Their_Savings_Account_Drops_Bellow_500()
        {
            var user = await GetLoggedUser();
            user.SavingsAccount.Balance = 0;

            user.SavingsAccount.Deposit(600.0);

            Assert.IsFalse(user.SavingsAccount.BalanceWarning);

            user.SavingsAccount.Withdraw(500.0);
            Debug.WriteLine(user.SavingsAccount.Balance);

            Assert.IsTrue(user.SavingsAccount.BalanceWarning);
        }

        [TestMethod]
        [ExpectedException(typeof(WithdrawUpTo500Exception))]
        public async Task User_Needs_To_Be_Able_To_Withdraw_Up_To_500_From_Checking_Account()
        {
            var user = await GetLoggedUser();
            user.CheckingAccount.Deposit(1000.0);
            user.CheckingAccount.Withdraw(600.0);
        }
    }
}
