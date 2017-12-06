using ATM.Data.Exceptions;
using System.Linq;

namespace ATM.Data
{
    public static class Authentication
    {
        public static User Login(string accountNumber, string password)
        {
            var db = new Database();

            var user = db.Users.First(u => u.CheckingAccount.Number.Equals(accountNumber) && u.Password.Equals(password));

            if (user == null)
            {
                throw new AuthenticationException("Account number or password invalid");
            }

            user.Logged = true;
            return user;
        }
    }
}
