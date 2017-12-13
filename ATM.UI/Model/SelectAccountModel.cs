using ATM.Data;
using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class SelectAccountModel:ObservableObject
    {
        public User User => BaseViewModel.LoggedUser;
        public bool IsATransfer => BaseViewModel.Transaction == BaseViewModel.Transactions.Transfer;

        public ICommand SelectAcountCommand => new DelegateCommand(SelectAccount);

        private void SelectAccount(object obj)
        {
            BaseViewModel.TransactionAccount = obj as IAccount;
            BaseViewModel.PageViewer.Navigate(typeof(SelectAmountPage));
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        private void GoBack(object obj)
        {
            BaseViewModel.PageViewer.Navigate(typeof(UserPage));
        }
    }
}
