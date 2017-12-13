using ATM.Data;
using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class UserPageModel : ObservableObject
    {
        public User User => BaseViewModel.LoggedUser;
        public bool SavingWarning => BaseViewModel.LoggedUser.SavingsAccount.BalanceWarning;

        public ICommand WithdrawCommand => new DelegateCommand(Withdraw);

        private void Withdraw(object obj)
        {
            BaseViewModel.Transaction = BaseViewModel.Transactions.Withdraw;
            BaseViewModel.PageViewer.Navigate(typeof(SelectAccountPage));
        }

        public ICommand DepositCommand => new DelegateCommand(Deposit);

        private void Deposit(object obj)
        {
            BaseViewModel.Transaction = BaseViewModel.Transactions.Deposit;
            BaseViewModel.PageViewer.Navigate(typeof(SelectAccountPage));
        }

        public ICommand TransferCommand => new DelegateCommand(Transfer);

        private void Transfer(object obj)
        {
            BaseViewModel.Transaction = BaseViewModel.Transactions.Transfer;
            BaseViewModel.PageViewer.Navigate(typeof(SelectAccountPage));
        }

        public ICommand LogoutCommand => new DelegateCommand(Logout);

        private void Logout(object obj)
        {
            BaseViewModel.LoggedUser = null;
            BaseViewModel.PageViewer.Navigate(typeof(LogInPage));
        }


    }
}
