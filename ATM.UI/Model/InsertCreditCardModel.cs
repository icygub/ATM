using ATM.UI.View;
using System.Windows.Input;
using ATM.Data;

namespace ATM.UI.Model
{
    class InsertCreditCardModel: ObservableObject
    {
        private string _creditCard;

        public bool ShowCreditCardBox => SharedModel.NonLoggedUser;
        public string CreditCard
        {
            get => _creditCard;
            set
            {
                _creditCard = value;
                RaisePropertyChangedEvent("CreditCard");
            } 
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        public void GoBack(object obj)
        {
            SharedModel.Amount = 0;
            if (SharedModel.NonLoggedUser)
            {
                SharedModel.PageViewer.Navigate(typeof(LogInPage));
            }
            else
            {
                SharedModel.PageViewer.Navigate(typeof(SelectAccountPage));
            }
        }

        public ICommand ConfirmCommand => new DelegateCommand(Confirm);

        public void Confirm(object obj)
        {
            if (SharedModel.NonLoggedUser)
            {
                var user = Authentication.LoginWithCreditCard(CreditCard);
                SharedModel.Transaction = SharedModel.Transactions.Withdraw;
                SharedModel.TransactionAccount = user.CreditCard;
            }

            SharedModel.PageViewer.Navigate(typeof(SelectAmountPage));
        }
    }
}
