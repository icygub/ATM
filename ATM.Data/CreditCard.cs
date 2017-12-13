using ATM.Data.Exceptions;
using System;

namespace ATM.Data
{
    public class CreditCard : IAccount
    {
        private double _balance;
        public string Number { get; }
        public double Balance => _balance;
        public bool BalanceWarning => false;

        public CreditCard()
        {
            var random = new Random();
            Number = random.Next(1, 12345678).ToString();
        }

        public CreditCard(string number)
        {
            Number = number;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }

        public void Withdraw(double withdraw)
        {
            if (withdraw > _balance) throw new InsufficientBalanceException();
            _balance -= withdraw;
        }

        public void TransferTo(IAccount account, double amount)
        {
            Withdraw(amount);
            account.Deposit(amount);
        }
    }
}
