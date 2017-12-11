using System.Threading.Tasks;
using ATM.Data;
using ATM.Data.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Test
{
    [TestClass]
    public class UserTest
    {
        private void CreateUser()
        {
            var db = Database.GetInstance();

            var checkingAccount = new CheckingAccount("123456789");
            var savingsAccount = new SavingsAccount("987654321");

            var user = new User(checkingAccount, savingsAccount)
            {
                Name = "Joe Doe",
                Password = "secret"
            };

            db.AddUser(user);

            db.Save();
        }

        private User GetLoggedUser()
        {
            CreateUser();

            const string accountNumber = "123456789";
            const string password = "secret";

            return Authentication.Login(accountNumber, password);
        }

        [TestMethod]
        public void User_Should_Be_Able_To_Login_Using_The_Account_Number_And_Password()
        {
            var loggedUser = GetLoggedUser();
            Assert.AreEqual(loggedUser.CheckingAccount.Number, "123456789");
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticationException))]
        public void  User_Should_Throw_An_Exception_When_The_Account_Number_Or_Password_Is_Wrong()
        {
            CreateUser();

            var accountNumber = "45845225";
            var password = "secret22222";

            Authentication.Login(accountNumber, password);
        }

        [TestMethod]
        public void User_Should_See_The_Balance_Of_SavingsAccount()
        {
            var user = GetLoggedUser();
            user.SavingsAccount.Deposit(500.0);
            Assert.AreEqual(user.SavingsAccount.Balance, 500.0);
        }

        [TestMethod]
        public void User_Should_See_The_Balance_Of_CheckingAccount()
        {
            var user = GetLoggedUser();
            user.CheckingAccount.Deposit(500.0);
            Assert.AreEqual(user.CheckingAccount.Balance, 500.0);
        }

        [TestMethod]
        public void User_Should_Be_Able_To_Transfer_From_Savings_To_Checking()
        {
            var user = GetLoggedUser();
            user.SavingsAccount.Deposit(100.0);
            user.CheckingAccount.Deposit(500.0);

            user.SavingsAccount.TransferTo(user.CheckingAccount, 50.0);

            Assert.AreEqual(user.CheckingAccount.Balance, 550.0);
            Assert.AreEqual(user.SavingsAccount.Balance, 50.0);
        }

        [TestMethod]
        public void User_Needs_To_Be_Warned_If_Their_Savings_Account_Drops_Bellow_500()
        {
            var user = GetLoggedUser();
            user.SavingsAccount.Deposit(600.0);

            Assert.IsFalse(user.SavingsAccount.BalanceWarning);

            user.SavingsAccount.Withdraw(300.0);

            Assert.IsTrue(user.SavingsAccount.BalanceWarning);
        }

        [TestMethod]
        [ExpectedException(typeof(WithdrawUpTo500Exception))]
        public void User_Needs_To_Be_Able_To_Withdraw_Up_To_500_From_Checking_Account()
        {
            var user = GetLoggedUser();
            user.CheckingAccount.Deposit(1000.0);

            user.CheckingAccount.Withdraw(600.0);
        }
    }
}
