using System;

namespace ATM.Data
{
    public abstract class Account
    {
        private double _balance = 0;
        private string _number;


        protected Account()
        {
            var random = new Random();
            _number = random.Next(1, 12345678).ToString();
        }

        protected Account(string number)
        {
            _number = number;
        }

        public double Balance
        {
            get { return _balance; }
        }

        public string Number
        {
            get { return _number; }
        }

        public void Deposit(double deposit)
        {
            _balance += deposit;
        }

        public void Withdraw(double withdraw)
        {
            _balance -= withdraw;
        }
    }
}
