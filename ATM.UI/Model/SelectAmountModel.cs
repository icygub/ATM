using ATM.UI.View;
using System;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class SelectAmountModel:ObservableObject
    {
        public ICommand SelectAmountCommand => new DelegateCommand(SelectAmount);

        public void SelectAmount(object obj)
        {
            SharedModel.Amount = Double.Parse(obj.ToString());
            SharedModel.PageViewer.Navigate(typeof(LoadingTransactionPage));
        }

        public ICommand SelectOtherAmountCommand => new DelegateCommand(SelectOtherAmount);

        public void SelectOtherAmount(object obj)
        {
            SharedModel.PageViewer.Navigate(typeof(EnterAmountPage));
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        public void GoBack(object obj)
        {
            SharedModel.TransactionAccount = null;
            if (SharedModel.NonLoggedUser)
            {
                SharedModel.PageViewer.Navigate(typeof(InsertCreditCardPage));
            }
            else
            {
                SharedModel.PageViewer.Navigate(typeof(SelectAccountPage));
            }
            
        }
    }
}
