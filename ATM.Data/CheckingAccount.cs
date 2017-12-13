using ATM.Data.Exceptions;
using System;

namespace ATM.Data
{
    public class CheckingAccount : IAccount
    {
        public string Number { get; set; }
        public double Balance { get; set; }
        public bool BalanceWarning => false;

        public CheckingAccount()
        {
        }

        public CheckingAccount(string number)
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
            if (withdraw > 500.0) throw new WithdrawUpTo500Exception();
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
