using ATM.Data;
using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class UserPageModel : ObservableObject
    {
        public User User => SharedModel.LoggedUser;
        public bool SavingWarning => SharedModel.LoggedUser.SavingsAccount.BalanceWarning;

        public ICommand WithdrawCommand => new DelegateCommand(Withdraw);

        private void Withdraw(object obj)
        {
            SharedModel.Transaction = SharedModel.Transactions.Withdraw;
            SharedModel.PageViewer.Navigate(typeof(SelectAccountPage));
        }

        public ICommand DepositCommand => new DelegateCommand(Deposit);

        private void Deposit(object obj)
        {
            SharedModel.Transaction = SharedModel.Transactions.Deposit;
            SharedModel.PageViewer.Navigate(typeof(SelectAccountPage));
        }

        public ICommand TransferCommand => new DelegateCommand(Transfer);

        private void Transfer(object obj)
        {
            SharedModel.Transaction = SharedModel.Transactions.Transfer;
            SharedModel.PageViewer.Navigate(typeof(SelectAccountPage));
        }

        public ICommand LogoutCommand => new DelegateCommand(Logout);

        private void Logout(object obj)
        {
            SharedModel.LoggedUser = null;
            SharedModel.PageViewer.Navigate(typeof(LogInPage));
        }


    }
}
