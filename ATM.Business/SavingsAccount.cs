using System;

namespace ATM.Business
{
    public class SavingsAccount : Account
    {
        public SavingsAccount() : base()
        {
        }

        public SavingsAccount(string number) : base(number)
        {
        }

        public bool BalanceWarning => Balance < 500.0;

        public void TransferTo(CheckingAccount checkingAccount, double transferredMoney)
        {
            Withdraw(transferredMoney);
            checkingAccount.Deposit(transferredMoney);
        }
    }
}
