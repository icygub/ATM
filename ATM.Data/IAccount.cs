using System;

namespace ATM.Data
{
    public interface IAccount
    {
        string Number { get; }
        double Balance { get; }
        bool BalanceWarning { get;  }
        void Deposit(Double amount);
        void Withdraw(Double amount);
        void TransferTo(IAccount account, Double amount);
    }
}
