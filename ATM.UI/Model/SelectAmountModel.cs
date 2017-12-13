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
            BaseViewModel.Amount = Double.Parse(obj.ToString());
            if (BaseViewModel.LoggedUser == null)
                BaseViewModel.PageViewer.Navigate(typeof(InsertCreditCardPage));
            else
                BaseViewModel.PageViewer.Navigate(typeof(LoadingTransactionPage));
        }

        public ICommand SelectOtherAmountCommand => new DelegateCommand(SelectOtherAmount);

        public void SelectOtherAmount(object obj)
        {
            BaseViewModel.PageViewer.Navigate(typeof(EnterAmountPage));
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        public void GoBack(object obj)
        {
            BaseViewModel.TransactionAccount = null;
            BaseViewModel.PageViewer.Navigate(typeof(SelectAccountPage));
        }
    }
}
