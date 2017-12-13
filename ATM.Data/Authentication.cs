using ATM.Data.Exceptions;
using System.Linq;

namespace ATM.Data
{
    public static class Authentication
    {
        public static User Login(string accountNumber, string password)
        {
            var db = Database.GetInstance();
            var users = db.GetUsers();

            var user = users.FirstOrDefault(u => u.CheckingAccount.Number.Equals(accountNumber) && u.Password.Equals(password));

            if (user == null)
            {
                throw new AuthenticationException("Account number or password invalid");
            }

            return user;
        }

        public static User LoginWithCreditCard(string creditCard)
        {
            var db = Database.GetInstance();
            var users = db.GetUsers();

            var user = users.FirstOrDefault(u => u.CreditCard.Number.Equals(creditCard));

            if (user == null)
            {
                throw new AuthenticationException("Credit Card invalid");
            }

            return user;
        }
    }
}
