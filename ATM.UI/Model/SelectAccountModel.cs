using ATM.Data;
using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class SelectAccountModel:ObservableObject
    {
        public User User => SharedModel.LoggedUser;
        public bool ShowCreditCardButton => SharedModel.Transaction == SharedModel.Transactions.Withdraw;

        public bool IsATransfer => SharedModel.Transaction == SharedModel.Transactions.Transfer;

        public ICommand SelectAcountCommand => new DelegateCommand(SelectAccount);

        private void SelectAccount(object obj)
        {
            SharedModel.TransactionAccount = obj as IAccount;

            if (SharedModel.TransactionAccount is CreditCard)
            {
                SharedModel.PageViewer.Navigate(typeof(InsertCreditCardPage));
            }
            else
            {
                SharedModel.PageViewer.Navigate(typeof(SelectAmountPage));
            }
           
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        private void GoBack(object obj)
        {
            SharedModel.PageViewer.Navigate(typeof(UserPage));
        }
    }
}
