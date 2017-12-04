using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Business
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public CheckingAccount CheckingAccount { get; }
        public SavingsAccount SavingsAccount { get; }

        public User()
        {
            SavingsAccount = new SavingsAccount();
            CheckingAccount = new CheckingAccount();
        }

        public User(CheckingAccount checkingAccount, SavingsAccount savingsAccount)
        {
            SavingsAccount = savingsAccount;
            CheckingAccount = checkingAccount;
        }

    }
}
