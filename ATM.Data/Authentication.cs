using ATM.Data.Exceptions;
using System.Linq;

namespace ATM.Data
{
    public static class Authentication
    {
        public static User Login(string accountNumber, string password)
        {
            //var db = Database.GetInstance();
            //var users = db.GetUsers();

            //var user = users.First(u => u.CheckingAccount.Number.Equals(accountNumber) && u.Password.Equals(password));

            //if (user == null)
            //{
            //    throw new AuthenticationException("Account number or password invalid");
            //}

            if (accountNumber != "123456" || accountNumber == null || password != "secret" || password == null)
            {
                throw new AuthenticationException("Account number or password invalid");
            }

            var checkingAccount = new CheckingAccount("123456789");
            checkingAccount.Deposit(100000);
            var savingsAccount = new SavingsAccount("987654321");
            savingsAccount.Deposit(100000);
            var creditCard = new CreditCard("12323334");
            creditCard.Deposit(100000);

            var user = new User(checkingAccount, savingsAccount, creditCard)
            {
                Name = "Joe Doe",
                Logged = true
            };

            return user;
        }

        public static User LoginWithCreditCard(string creditCard)
        {
            if (creditCard != "123456" || creditCard == null)
            {
                throw new AuthenticationException("Credit Card invalid");
            }

            var checkingAccount = new CheckingAccount("123456789");
            checkingAccount.Deposit(100000);
            var savingsAccount = new SavingsAccount("987654321");
            savingsAccount.Deposit(100000);
            var creditCardAcc = new CreditCard("12323334");
            creditCardAcc.Deposit(100000);

            var user = new User(checkingAccount, savingsAccount, creditCardAcc)
            {
                Name = "Joe Doe",
                Logged = true
            };

            return user;
        }
    }
}
