using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATM.UI.View;

namespace ATM.UI.Model
{
    class SelectAmountModel:ObservableObject
    {
        public ICommand SelectAmountCommand => new DelegateCommand(SelectAmount);

        public void SelectAmount(object obj)
        {
            BaseViewModel.Amount = Double.Parse(obj.ToString());
            BaseViewModel.PageViewer.Navigate(typeof(InsertCreditCardPage));
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
