using ATM.Data.Exceptions;
using System;

namespace ATM.Data
{
    public class CreditCard : IAccount
    {
        private double _balance;
        public string Number { get; set; }
        public double Balance { get; set; }
        public bool BalanceWarning => false;

        public CreditCard()
        {
        }

        public CreditCard(string number)
        {
            Number = number;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Commit();
        }

        public void Withdraw(double withdraw)
        {
            if (withdraw > Balance) throw new InsufficientBalanceException();
            Balance -= withdraw;
            Commit();
        }

        public void TransferTo(IAccount account, double amount)
        {
            Withdraw(amount);
            account.Deposit(amount);
            Commit();
        }

        private async void Commit()
        {
            var db = Database.GetInstance();
            await db.Save();
        }
    }
}
