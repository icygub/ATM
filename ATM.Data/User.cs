using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Data
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public CheckingAccount CheckingAccount { get; set; }
        public SavingsAccount SavingsAccount { get; set; }
        public CreditCard CreditCard { get; set; }
        public bool Logged { get; internal set; }

        public User()
        {
            //SavingsAccount = new SavingsAccount();
            //CheckingAccount = new CheckingAccount();
            //CreditCard = new CreditCard();
            Logged = false;
        }

        public User(CheckingAccount checkingAccount, SavingsAccount savingsAccount)
        {
            SavingsAccount = savingsAccount;
            CheckingAccount = checkingAccount;
        }

        public User(CheckingAccount checkingAccount, SavingsAccount savingsAccount, CreditCard creditCard)
        {
            SavingsAccount = savingsAccount;
            CheckingAccount = checkingAccount;
            CreditCard = creditCard;
        }

    }
}
