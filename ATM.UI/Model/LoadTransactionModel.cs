using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class LoadTransactionModel:ObservableObject
    {
        public ICommand ContinueCommand => new DelegateCommand(Continue);

        public void Continue(object obj)
        {
            switch (BaseViewModel.Transaction)
            {
                case BaseViewModel.Transactions.Withdraw:
                    BaseViewModel.TransactionAccount.Withdraw(BaseViewModel.Amount);
                    break;
                case BaseViewModel.Transactions.Deposit:
                    BaseViewModel.TransactionAccount.Deposit(BaseViewModel.Amount);
                    break;
                case BaseViewModel.Transactions.Transfer:
                    break;
            }

            BaseViewModel.PageViewer.Navigate(typeof(CompletedTransactionPage));
        }
    }
}
